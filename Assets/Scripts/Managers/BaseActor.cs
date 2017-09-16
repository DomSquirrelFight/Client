using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System;
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
    static public BaseActor CreatePlayer(string name/*角色名称*/, eRoleID roldid/*角色ID*/, Vector3 pos = default(Vector3)/*模型出生位置*/, Quaternion rot = default(Quaternion)/*模型出生朝向*/, bool bCanJump = true,
        eCharacSide side = eCharacSide.Side_Player, eCharacType type = eCharacType.Type_Major
        )
    {

        #region 创建外层对象
        GameObject Player = new GameObject(name);
        Player.transform.position = Vector3.zero;
        Player.transform.rotation = Quaternion.identity;
        Player.transform.localScale = Vector3.one;
        #endregion

        #region 创建模型
        BaseActor ba = Player.AddComponent<BaseActor>();//加载BaseActor脚本

        CreateActor(roldid, ba, pos, rot);//加载模型
        #endregion

        #region 获取跳跃数据
        if (bCanJump)
        {
            //获取小跳数据
            UnityEngine.Object _obj = Resources.Load("Prefabs/Maps/FightTest/SmallJumpDataStore");
            GameObject obj = Instantiate(_obj) as GameObject;
            ba.m_cSmallJumpDataStore = obj.GetComponent<JumpDataStore>();
            ba.m_cSmallJumpDataStore.transform.parent = ba.transform;//设置小跳的父类
        }
        #endregion

        #region 角色属性
        switch (type)
        {
            case eCharacType.Type_Major:
                {
                    if (
                      null != ba.PlayerMgr/*读取角色管理器*/ ||
                      null != ba.CameraContrl/*相机实例对象*/ ||
                      null != ba.RB/*加载刚体*/
                      )
                    {
                        ba.PlayerMgr.OnStart(ba);//启动角色管理器
                        ba.CameraContrl.OnStart(ba);//启动相机
                    }
                    ba.baseattr = (BaseAttr)ba.gameObject.GetOrAddComponent<PlayerAttr>();
                    break;
                }
            case eCharacType.Type_NormalNpc:
            case eCharacType.Type_Boss:
                {
                    if (
                     null != ba.PlayerMgr/*读取角色管理器*/ ||
                     null != ba.RB/*加载刚体*/
                     )
                    {
                        ba.PlayerMgr.OnStart(ba);//启动角色管理器
                    }
                    ba.baseattr = (BaseAttr)ba.gameObject.GetOrAddComponent<NpcAttr>();
                    break;
                }
        }
        ba.BaseAtt.InitAttr(side, type);
        #endregion

        return ba;
    }

    /// <summary>
    /// 创建角色模型实例对象，并返回
    /// </summary>
    /// <returns></returns>
    static public GameObject CreateActor(eRoleID roleId, BaseActor baparent, Vector3 pos = default(Vector3)/*模型出生位置*/, Quaternion rot = default(Quaternion)/*模型出生朝向*/)
    {
        string route = "";
        switch (roleId)
        {
            case eRoleID.Role_Major:
                {
                    route = "Prefabs/Character/Penguins/Prefab/PenguinA";
                    break;
                }
            case eRoleID.Role_SoliderV1:
                {
                    break;
                }
        }
        UnityEngine.Object obj = Resources.Load(route);
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

    #region 小跳类
    private JumpDataStore m_cSmallJumpDataStore;
    public JumpDataStore SmallJumpDataStore
    {
        get
        {
            return m_cSmallJumpDataStore;
        }
    }
    #endregion

    #region 玩家状态

    #endregion

}
