using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System;
using Assets.Scripts.AssetInfoEditor;
using Assets.Scripts.WayFinding;
public class BaseActor : MonoBehaviour
{

    #region 刚体
    private Rigidbody rb;
    public Rigidbody RB
    {
        get
        {
            if(null == rb)
                rb = m_oActor.GetOrAddComponent<Rigidbody>();
            return rb;
        }
    }

    public Vector3 Velocity
    {
        get
        {
            return RB.velocity;
        }
        set
        {
            if (value != RB.velocity)
                RB.velocity = value;
        }
    }

    #endregion

    #region 模型实例
    private GameObject m_oActor;
    public GameObject Actor
    {
        get
        {
            return m_oActor;
        }
    }
    #endregion

    #region 角色属性
    private BaseAttr baseattr;
    public BaseAttr BaseAtt
    {
        get
        {
            return baseattr;
        }
    }

    #endregion

    #region 动作树行为脚本
    private StateBehaviour statebe;
    public StateBehaviour StateBehav
    {
        get
        {
            if (null == statebe)
            {
                statebe = AM.GetBehaviour<StateBehaviour>();
            }
            return statebe;
        }
    }
    #endregion

    #region 角色role id

    int roleid;

    public int RoleID
    {
        get
        {
            return roleid;
        }
    }

    #endregion

    #region AnimatorMgr
    private AnimatorMgr animatormgr;
    public AnimatorMgr AnimMgr
    {
        get
        {
            if (null == animatormgr)
            {
                animatormgr = Actor.GetOrAddComponent<AnimatorMgr>();
            }
            return animatormgr;
        }
    }
    #endregion

    #region 角色行为参数
    CRunningForward rf;
    public CRunningForward CRunFor
    {
        get
        {
            return rf;
        }
    }
    RoleBehavInfos[] ArrRoleBehaInfos;
    public void SetCurRoleBehavInfos(eRunMode mode)
    {
        switch (mode)
        {
            case eRunMode.eRun_Horizontal:
                {
                    rolebehainfo = ArrRoleBehaInfos[0];
                    break;
                }
            case eRunMode.eRun_Vertical:
                {
                    rolebehainfo = ArrRoleBehaInfos[1];
                    if (null == rf)
                    {
                        rf = new CRunningForward(Actor.transform, rolebehainfo.RunState, rolebehainfo.RoleMoveHorizontalSpeed, rolebehainfo.RoleMoveHorizontalDuration, rolebehainfo.RoleMoveHorizontalDistance);
                    }
                    break;
                }
        }
    }
    #endregion

    #region 加载角色
    /// <summary>
    /// 创建角色，并将角色实例返回
    /// </summary>
    /// <returns></returns>
    static public BaseActor CreatePlayer(int roldid/*角色ID*/, Vector3 pos, Quaternion rot , Vector3 scale )
    {

        #region 加载Asset文件

        //角色信息
        RoleInfos roleInfos = DataRecordManager.GetDataInstance<RoleInfos>(roldid);
        if (null == roleInfos)
        {
            Debug.LogErrorFormat("Fail to find asset in route ({0})", roleInfos.strRolePath);
            return null;
        }

        //角色行为信息
        RoleBehavInfos rolebehainfos = DataRecordManager.GetDataInstance<RoleBehavInfos>(roldid * 10 + 1);
        if (null == rolebehainfos)
        {
            Debug.LogErrorFormat("Fail to find asset in RoleBehavInfos id ({0})", roldid * 10 + 1);
            return null;
        }

        RoleBehavInfos rolebehainfos1 = DataRecordManager.GetDataInstance<RoleBehavInfos>(roldid * 10 + 2);
        if (null == rolebehainfos)
        {
            Debug.LogErrorFormat("Fail to find asset in RoleBehavInfos id ({0})", roldid * 10 + 2);
            return null;
        }

        #endregion

        #region 创建外层对象
        GameObject Player = new GameObject(roleInfos.strRoleName);
        Player.transform.position = Vector3.zero;
        Player.transform.rotation = Quaternion.identity;
        Player.transform.localScale = Vector3.one;
        #endregion

        #region 创建模型
        BaseActor ba = Player.AddComponent<BaseActor>();//加载BaseActor脚本

        CreateActor(roldid, roleInfos.strRolePath, ba, pos, rot, scale);//加载模型
        #endregion

        #region 角色属性
        ba.roleid = roldid;
        ba.ArrRoleBehaInfos = new RoleBehavInfos[2];
        ba.ArrRoleBehaInfos[0] = rolebehainfos;
        ba.ArrRoleBehaInfos[1] = rolebehainfos1;
        switch (roleInfos.RunMode)
        {
            case eRunMode.eRun_Horizontal:
                {
                    ba.rolebehainfo = rolebehainfos;//初始化角色行为信息
                    break;
                }
            case eRunMode.eRun_Vertical:{
                    ba.rolebehainfo = rolebehainfos1;//初始化角色行为信息
                    break;
                }
        }
       
        switch (roleInfos.CharacType)
        {
            case eCharacType.Type_Major:
                {

                    ba.baseattr = (BaseAttr)ba.gameObject.GetOrAddComponent<PlayerAttr>();
                    ba.BaseAtt.InitAttr(roleInfos);
                    if (
                      null != ba.CameraContrl/*相机实例对象*/ ||
                      null != ba.RB/*加载刚体*/ ||
                      null != ba.SkillMgr ||
                      null != ba.AnimMgr
                      )
                    {
                        ba.CameraContrl.OnStart(ba);//启动相机
                        ba.SkillMgr.OnStart(ba);
                        ba.AnimMgr.OnStart(ba);
                    }
                   
                    ba.fsm = (FSMBehaviour)ba.gameObject.GetOrAddComponent<PlayerFSM>();
                    ba.InitShaderProperties();
                    break;
                }
            case eCharacType.Type_NormalNpc:
            case eCharacType.Type_Boss:
                {
                    ba.baseattr = (BaseAttr)ba.gameObject.GetOrAddComponent<NpcAttr>();
                    ba.BaseAtt.InitAttr(roleInfos);
                    if (
                     null != ba.RB/*加载刚体*/ ||
                     null != ba.SkillMgr ||
                     null != ba.AnimMgr
                     )
                    {
                        ba.SkillMgr.OnStart(ba);
                        ba.AnimMgr.OnStart(ba);
                    }

                    if (roleInfos.MonsterType != eMonsterType.MonType_Rock)
                    {
                        ba.fsm = (FSMBehaviour)ba.gameObject.GetOrAddComponent<AIEnemy>();
                        ba.InitShaderProperties();
                    }
                    break;
                }
        }
    
    
        #endregion

        return ba;
    }

    /// <summary>
    /// 创建角色模型实例对象，并返回
    /// </summary>
    /// <returns></returns>
    static public GameObject CreateActor(int roleId, string path, BaseActor baparent, Vector3 pos , Quaternion rot , Vector3 scale)
    {

        UnityEngine.Object obj = Resources.Load(path);
        GameObject actor = Instantiate(obj) as GameObject;
        actor.name = obj.name;
        actor.transform.parent = baparent.transform;
        actor.transform.localPosition = pos;
        actor.transform.localRotation = rot;
        actor.transform.localScale = scale;
        baparent.m_oActor = actor;

        return actor;
    }
    #endregion

    #region 角色控制器
    private PlayerManager m_playermgr;
    public PlayerManager PlayerMgr
    {
        get
        {
            if(null == m_playermgr)
                m_playermgr = m_oActor.AddComponent<PlayerManager>();
            return m_playermgr;
        }
    }
    #endregion

    #region 动画控制器
    private Animator am;
    public Animator AM
    {
        get
        {
            if(null == am)
                am = m_oActor.GetComponent<Animator>();
            return am;
        }
    }
    #endregion

    #region 模型transform
    private Transform atransform;
    public Transform ActorTrans
    {
        get
        {
            return m_oActor.transform;
        }
    }
    #endregion

    #region 主相机脚本
    private CameraController cc;
    public CameraController CameraContrl
    {
        get
        {
            if (null == cc)
                    cc = Camera.main.transform.parent.GetComponent<CameraController>();
            return cc;
        }
    }
    #endregion

    #region 角色大小, 碰撞器

    private BoxCollider bc;
    public BoxCollider BC
    {
        get
        {
            if(null == bc)
                bc = Actor.GetOrAddComponent<BoxCollider>();
            return bc;
        }
    }

    float actorsize = 0f;
    public float ActorSize
    {
        get
        {
            if (0f == actorsize)
                actorsize = Actor.GetComponent<BoxCollider>().size.x;
            return actorsize;
        }
    }

    float actorheight = 0f;
    public float ActorHeight
    {
        get
        {
            if (0f == actorheight)
                actorheight = Actor.GetComponent<BoxCollider>().size.y;
            return actorheight;
        }
    }

    //public float ActorMiddleYPos
    //{
    //    get
    //    {
    //        return ActorTrans.position.y + ActorHeight * 0.5f;
    //    }
    //}

    //public Vector3 ActorMiddlePoint
    //{
    //    get
    //    {
    //        return new Vector3(ActorTrans.position.x, ActorMiddleYPos, ActorTrans.position.z);
    //    }
    //}






    #endregion

    #region 技能管理器

    private SkillManager skillmgr;
    public SkillManager SkillMgr
    {
        get
        {
            if (null == skillmgr)
            {
                skillmgr = gameObject.GetOrAddComponent<SkillManager>();
            }
            return skillmgr;
        }
    }

    #endregion

    #region 玩家状态

    #endregion

    #region 状态机
    private FSMBehaviour fsm;
    public FSMBehaviour FSM
    {
        get
        {
            return fsm;
        }
    }
    #endregion

    #region 受伤改变透明度
    Shader m_sOrig;
    SkinnedMeshRenderer m_smr;
    Shader m_sDeadShader = null;
    float m_alpha = 0.6f;
    float m_aplhaStep = 0.5f;
    void InitShaderProperties()
    {
        m_smr = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        m_sOrig = m_smr.materials[0].shader;
    }

    public void StartChangingAlpha()
    {
        m_alpha = 0.6f;
        m_aplhaStep = 0.5f;
        m_sDeadShader = null;
        StartCoroutine(ChangingAlpha());
    }

    IEnumerator ChangingAlpha()
    {

        if (null == m_sDeadShader)
        {
            m_sDeadShader = Shader.Find("UnityChan/Skin - Transparent");
            m_smr.materials[0].shader = m_sDeadShader;
            m_smr.materials[0].SetVector("_Color", Vector4.one);
        }
        while ( RB.isKinematic == true &&  BC.enabled == false)
        {
            if (m_alpha <= 0 || m_alpha >= 1.0f)
            {
                m_aplhaStep = 0 - m_aplhaStep;
            }
            m_smr.materials[0].SetVector("_Color", new Vector4(1, 1, 1, m_alpha));
            m_alpha -= Time.deltaTime * m_aplhaStep;
            yield return null;
        }

        m_smr.materials[0].shader = m_sOrig;
      
    }

    public void EndChangingAlpha(float wait)
    {
        Invoke("WaitingChangingBack", wait);
    }

    void WaitingChangingBack()
    {
        RB.isKinematic = false;
        BC.enabled = true;
        FSM.SetTransition(StateID.Idle);
       // StopCoroutine(ChangingAlpha());
    }

    #endregion

    #region HoldBoxDir, HoldBoxTransform

    Transform holdboxtrans;
    public Transform HoldBoxTrans
    {
        get
        {
            return holdboxtrans;
        }
        set
        {
            if (value != holdboxtrans)
                holdboxtrans = value;
        }
    }

    private Vector3 holdboxdir;
    public Vector3 HoldBoxDir
    {
        get
        {
            return holdboxdir;
        }
        set
        {
            if (value != holdboxdir)
                holdboxdir = value;
        }
    }

    #endregion

    #region 销毁物理系统

    public void DestroyPhysics()
    {
        Destroy(BC);
        Destroy(RB);
    }
    #endregion

    #region 角色行为信息
    private RoleBehavInfos rolebehainfo;
    public RoleBehavInfos RoleBehaInfos
    {
        get
        {
            return rolebehainfo;
        }
    }

    #endregion

    #region 数据回收
    void OnDisable()
    {
        ArrRoleBehaInfos = null;
        rf.ClearData(); rf = null;
    }
    #endregion

}
