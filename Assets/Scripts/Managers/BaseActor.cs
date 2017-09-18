using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System;
using Assets.Scripts.RoleInfoEditor;
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

    #region 加载角色
    /// <summary>
    /// 创建角色，并将角色实例返回
    /// </summary>
    /// <returns></returns>
    static public BaseActor CreatePlayer(int roldid/*角色ID*/, Vector3 pos = default(Vector3)/*模型出生位置*/, Quaternion rot = default(Quaternion)/*模型出生朝向*/)
    {

        #region 加载Asset文件
        string assetpath = GlobalHelper.SResAssetRoute + roldid.ToString();
        RoleInfos roleInfos = (Resources.Load(assetpath)) as RoleInfos;
        if (null == roleInfos)
        {
            Debug.LogErrorFormat("Fail to find asset in route ({0})", assetpath);
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

        CreateActor(roldid, roleInfos.strRolePath, ba, pos, rot);//加载模型
        #endregion

        #region 角色属性
        switch (roleInfos.CharacType)
        {
            case eCharacType.Type_Major:
                {

                    ba.baseattr = (BaseAttr)ba.gameObject.GetOrAddComponent<PlayerAttr>();
                    ba.BaseAtt.InitAttr(roleInfos);
                    if (
                      null != ba.PlayerMgr/*读取角色管理器*/ ||
                      null != ba.CameraContrl/*相机实例对象*/ ||
                      null != ba.RB/*加载刚体*/
                      )
                    {
                        ba.PlayerMgr.OnStart(ba);//启动角色管理器
                        ba.CameraContrl.OnStart(ba);//启动相机
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
                     null != ba.PlayerMgr/*读取角色管理器*/ ||
                     null != ba.RB/*加载刚体*/
                     )
                    {
                        ba.PlayerMgr.OnStart(ba);//启动角色管理器
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
    static public GameObject CreateActor(int roleId, string path, BaseActor baparent, Vector3 pos = default(Vector3)/*模型出生位置*/, Quaternion rot = default(Quaternion)/*模型出生朝向*/)
    {

        UnityEngine.Object obj = Resources.Load(path);
        GameObject actor = Instantiate(obj) as GameObject;
        actor.name = obj.name;
        actor.transform.parent = baparent.transform;
        actor.transform.localPosition = pos;
        actor.transform.localRotation = rot;
        actor.transform.localScale = Vector3.one;
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
                    cc = Camera.main.GetComponent<CameraController>();
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

    public float ActorMiddleYPos
    {
        get
        {
            return ActorTrans.position.y + ActorHeight * 0.5f;
        }
    }

    public Vector3 ActorMiddlePoint
    {
        get
        {
            return new Vector3(ActorTrans.position.x, ActorMiddleYPos, ActorTrans.position.z);
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
            m_sDeadShader = Shader.Find("Custom/Alpha");
            m_smr.materials[0].shader = m_sDeadShader;
        }
        while (true)
        {
            if (m_alpha <= 0)
            {
                m_aplhaStep = 0 - m_aplhaStep;
            }
            m_smr.materials[0].SetFloat("_AlphaScale", m_alpha);
            m_alpha -= Time.deltaTime * 0.5f;
            yield return null;
        }
      
    }


    public void EndChangingAlpha()
    {
        m_smr.materials[0].shader = m_sOrig;


        StopCoroutine(ChangingAlpha());
    }


    #endregion


}
