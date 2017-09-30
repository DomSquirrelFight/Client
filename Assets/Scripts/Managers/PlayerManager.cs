using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System.Linq;
using Assets.Scripts.Helper;
using Assets.Scripts.AssetInfoEditor;
using System;
public class PlayerManager : MonoBehaviour
{

    #region 变量

    SkillManager SkillMgr;
    //ePlayerBehaviour m_ePlayerBeha = ePlayerBehaviour.eBehav_Normal;                                                                        //角色行为
    ePlayerNormalBeha PlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;  
    ePlayerNormalBeha m_ePlayerNormalBehav                                            //角色普通行为
    {
        get
        {
            return PlayerNormalBehav;
        }
        set
        {
            if (value != PlayerNormalBehav)
            {
                PlayerNormalBehav = value;
            }
        }
    }

    //對外開放屬性
    public ePlayerNormalBeha PlayerBehaviour
    {
        get
        {
            return m_ePlayerNormalBehav;
        }
    }

    bool bGrounded = true;                                                                                                                                             //判定角色是否落地
    bool m_bGounded
    {
        get
        {
            return bGrounded;
        }
        set
        {
            if (value != bGrounded)
            {
                //if (bGrounded == true && value == false && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded)
                //{
                //    DoBeforeFreeFall();//为自由下落做准备
                //}
                bGrounded = value;
            }
        }
    }                                                                                                                                                   //判定角色是否落地属性变量
    
    BaseActor Owner;                                                                                                                                                        //角色实例对象

    CameraController cc;                                                                                                                                                   //相机实例对象                                                   

    int mask;                                                                                                                                                                     //Ground Layer<用在射线>

    int BrickMask;                                                                                                                                                             //Brick Layer <用在射线>

    int BoxMask;

    public int NBoxMask
    {
        get
        {
            return BoxMask;
        }
    }

    int MaskGlossy;                                                                                                                                                          //层级平移位数<对比碰撞双方的层级>

    int BrickMaskGlossy;                                                                                                                                                 //层级平移位数<对比碰撞双方的层级>

    int BoxMaskGlossy;

    int NpcMaskGlossy;

    int NpcMask;

    int NpcGroundMaskGlossy;

    int NpcGroundMask;

    int WallMaskGlossy;

    int WallMask;

    int HoldBoxMaskGlossy;

    public int NHoldBoxMaskGlossy
    {
        get
        {
            return HoldBoxMaskGlossy;
        }
    }

    int HoldBoxMask;

    //JumpDataStore m_curJumpData;                                                                                                                                 //跳跃数据

    float TmpDis;                                                                                                                                                               //保存临时变量

    RaycastHit hitInfo;                                                                                                                                                       //射线检测数据

    Vector3 m_vCurForward;                                                                                                                                             //保存当前角色朝向

    bool m_bIsBlocked = false;                                                                                                                                         //判定横向是否被盒子阻挡了

    BoxCollider m_bcCurBox = null;
    bool m_bIsHoldBox = false;


    public float FPlayerJumpBeginYPos                                                                                                                            //角色起跳在Y轴方向的高度值
    {
        get
        {
            return fOrigHeight;
        }
    }
    ePlayerJumpDownState bCanJumpDown = ePlayerJumpDownState.CanJumpDown_NULL;
    ePlayerJumpDownState BCanJumpDown
    {
        get
        {
            return bCanJumpDown;
        }
        set
        {
            if (value != bCanJumpDown)
            {
                if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
                {
                    if (value == ePlayerJumpDownState.CanJumpDown_YES)                     //ui fight 下跳按钮点亮
                    {
                        m_UISceneFight.BDisableJumpDown = false;
                    }
                    else if (value == ePlayerJumpDownState.CanJumpDown_NO)               // ui fight 下跳按钮变灰
                    {
                        m_UISceneFight.BDisableJumpDown = true;
                    }
                }
                bCanJumpDown = value;

            }
        }
    }                                                                                                                                              //是否可以下跳

    float fOrigHeight = 0f;                                                                                                         //开始跳跃或者下降前的高度

    
    bool m_bIsDescent = true;                                                                                                  //判断是否在下降
    
    float m_fStartTime = 0f;                                                                                                      //跳跃开始前的计时变量

    float m_fDuration = 0;                                                                                                        //保存跳跃的时长

    float m_fInitSpeed = 0f;

    Vector2 m_vInputMove;                                                                                                     //发送平移输入
    public Vector2 VInputMove
    {
        get
        {
            return m_vInputMove;
        }
    }

    UIScene_Fight m_UISceneFight;
    public UIScene_Fight UISceneFight
    {
        get
        {
            return m_UISceneFight;
        }
    }

    public  float SBoxSize = 0.6f;

   // public NotifyState m_delNotifyState;                                                                                  //通知ui fight现在按钮的状态

    public float SMoveSpeed = 4f;

    public float SBackSpeed = 5f;
    public float SRotSpeed = 60f;

    #endregion

    #region 外部接口 / 系统接口
    public void OnStart(BaseActor owner, PathArea birthArea)
    {
        NpcMaskGlossy = LayerMask.NameToLayer("NPC");
        NpcMask = 1 << NpcMaskGlossy;

        MaskGlossy = LayerMask.NameToLayer("Ground");
        mask = 1 << MaskGlossy;
        BrickMaskGlossy = LayerMask.NameToLayer("Brick");
        BrickMask = 1 << BrickMaskGlossy;

        BoxMaskGlossy = LayerMask.NameToLayer("Box");
        BoxMask = 1 << BoxMaskGlossy;

        NpcGroundMaskGlossy = LayerMask.NameToLayer("NpcGround");
        NpcGroundMask = 1 << NpcGroundMaskGlossy;

        WallMaskGlossy = LayerMask.NameToLayer("Wall");
        WallMask = 1 << WallMaskGlossy;

        HoldBoxMaskGlossy = LayerMask.NameToLayer("HoldBox");
        HoldBoxMask = 1 << HoldBoxMaskGlossy;


        WayFindingMaskGlossy = LayerMask.NameToLayer("WayFinidngBox");
        WayFinidngMask = 1 << WayFindingMaskGlossy;

        Owner = owner;

        SkillMgr = Owner.SkillMgr;

        if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
        {
            m_UISceneFight = Helpers.UIScene<UIScene_Fight>();
            m_UISceneFight.OnStart(Owner);
        }
        cc = Owner.CameraContrl;
        //m_curJumpData = Owner.SmallJumpDataStore;

        //角色垂直上跳，碰到brick的距离
        m_fUpDisForBrick = Owner.BaseAtt.RoleInfo.fJumpHeight - 0.2f - Owner.ActorHeight + 0.1f;

        float tmp = Owner.BaseAtt.RoleInfo.fJumpHeight + 0.1f;
        float dis = Mathf.Sqrt(tmp * tmp * 2);
        //float halfDiagonal = Mathf.Sqrt(Owner.ActorHeight * Owner.ActorHeight * 2) * 0.5f;
        m_fBiasDisForBrick = dis;// -halfDiagonal + 0.1f;
        //CalculateSlideDis();
        SMoveSpeed = Owner.BaseAtt.RoleInfo.RoleMoveSpeed;
        SBackSpeed = Owner.BaseAtt.RoleInfo.RoleBackSpeed;
        SRotSpeed = Owner.BaseAtt.RoleInfo.RoleRotSpeed;

        //根据出生点 : 形成初始化的路线.
        ArrtTPoints = new Transform[birthArea.RoutePoints.Length];
        birthArea.RoutePoints.CopyTo(ArrtTPoints, 0);
        PathPercent = min;
        PahtAreaCtrl = birthArea.transform.parent;
        CurArea = birthArea;
        m_sStellerCat.PathPoints = BezierLine.GetBezierPoints(ArrtTPoints);
        //加载贝塞尔曲线
       GameObject bezierline=  Instantiate(Resources.Load("Prefabs/Maps/FightTest/BezierLine")) as GameObject;
        bezierline.transform.position = Vector3.zero;

    }

    void Update()
    {
        if (!Owner)
            return;

        if (Owner.BaseAtt.RoleInfo.CharacType != eCharacType.Type_Major)
            return;

        if (Owner.FSM.IsInState(StateID.Injured))
            return;

        CalMoveInput();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
            {
                if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K))
                    CalJumpUp();
                else if (Input.GetKeyDown(KeyCode.J))
                    CalJumpDown();

                if (Input.GetKeyDown(KeyCode.U))
                    SkillMgr.UseSkill(eSkillType.SkillType_ThrowBox);
            }
        }

        //播放位移动画
        PlayMoveAnim();
        if (0f != m_vInputMove.x)
        {
            if (!CheckMoveBoundaryBlock())//判定横向是否超出朝向边界
            {
                if (!RayCastBlock())//横向阻挡
                {
                    //执行旋转操作
                    RotatePlayerAlongBezier();
                    //执行move操作
                    TranslatePlayer();
                }
            }
        }

        //执行小跳跃
        JumpBehaviour();

        //自由下落
        FreeFall();

        //执行下跳操作
        JumpDownBehaviour();

        //复位数据
        ResetAllData();

    }

    #endregion

    #region 检测输入
    float he, ve;
    public void CalMoveInput()                                              //获取平移输入
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            m_vInputMove = m_UISceneFight.DirPos; //m_vInputMove 需要时时获取UIScene_JoyStick的摇杆数据
        }
        else
        {
            he = Input.GetAxis("Horizontal");
            //ve = Input.GetAxis("Vertical");
            if (0f == he && (m_UISceneFight))
            {
                m_vInputMove = m_UISceneFight.DirPos; //否则 用摇杆数据
            }
            else if (0f != he)
            {
                //m_vInputMove.x = he;
                if (he > 0)
                {
                    m_vInputMove.x = 1;
                }
                else if (he < 0)
                    m_vInputMove.x = -1;

            }
        }
    }

    public bool CalJumpUp()                                              //获取跳跃输入
    {
        if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded )
        {
            DoBeforeJump(ePlayerNormalBeha.eNormalBehav_SmallJump, Owner.BaseAtt.RoleInfo.fInitJumpSpeed, false);
                return true;
        }
        return false;
    }

    public bool CalJumpDown()
    {

            if (!CheckJumpDown())                   //检查下落的下方是否有盒子.
            {
                return false;
            }   
            
            if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && BCanJumpDown == ePlayerJumpDownState.CanJumpDown_YES)
            {
#if UNITY_EDITOR
                Debug.Log("Can jump down");
#endif
    
                JumpThroughState = true;
                DoBeforeJump(ePlayerNormalBeha.eNormalBehav_JumpDown, 0f, true);
                return true;
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("Can't jump down");
#endif
            }
        return false;
    }
    Vector3 pos;


    #endregion

    #region 检测碰撞
    bool m_bCollisionEntered = false;
    void OnCollisionEnter(Collision other)
    {
        m_bCollisionEntered = true;
        if (other.contacts.Length > 0)
        {
            if (other.contacts[0].thisCollider.gameObject.layer == NpcMaskGlossy)                                    //角色碰到了ground, brick or box
            {
                if (other.contacts[0].otherCollider.gameObject.layer == MaskGlossy)
                {
                    if (m_bIsDescent)
                    {
                        SetJumpDownState(other);
                    }
                }
                else if (other.contacts[0].otherCollider.gameObject.layer == BrickMaskGlossy)                                           //如果判定接触到的是brick
                {
                    OperateGround(other, BrickMask);
                }
                else if (other.contacts[0].otherCollider.gameObject.layer == BoxMaskGlossy)                              //如果判定碰到的是box
                {
                    OperateGround(other, BoxMask);
                }
                else if (other.contacts[0].otherCollider.gameObject.layer == NpcMaskGlossy)                             //如果碰到了npc
                {
                    if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
                    {
                        UnityEngine.Object obj = Resources.Load("IGSoft_Projects/Buffs/5010101");
                        GameObject tmp = Instantiate(obj) as GameObject;
                        ActionInfos acInfos = tmp.GetComponent<ActionInfos>();
                        acInfos.SetOwner(Owner.gameObject, Owner, null);
                    }
                }
              
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (m_bCollisionEntered == false)
            OnCollisionEnter(other);
    }

    void OperateGround(Collision other, int layer)                                //处理落地逻辑
    {
        float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;

        pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

        if (Physics.SphereCast(pos, SBoxSize * 0.5f, Vector3.down, out hitInfo, Owner.ActorHeight * 0.5f + 0.1f, layer))     //如果在角色垂直向下方向射到了box，那么处理落地逻辑
        {
            if (hitInfo.collider.gameObject == other.collider.gameObject && m_bIsDescent == true)//在下降过程中
            {

#if UNITY_EDITOR
                if(layer == mask)
                    Debug.Log(1);
#endif

                SetJumpDownState(other);
            }
        }
        else if (Physics.SphereCast(pos, SBoxSize * 0.5f, Vector3.up, out hitInfo, Owner.ActorHeight * 0.5f + 0.1f, layer))
        {
            if (hitInfo.collider.gameObject == other.collider.gameObject && m_bIsDescent == false)//在上升过程中
            {
#if UNITY_EDITOR
                if(layer == mask)
                    Debug.Log(1);
#endif
                Owner.Velocity= Vector3.zero;
            }

        }
    }

    #endregion
 
    #region Jump
    Transform m_tDescent;
    bool CheckJumpDown()                                                 //解决在下跳的时候，下一层有很多的盒子，导致角色不能完全跳下去，而卡在两个层中间
    {

        //检测到了下面有box
        if (Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.4f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.down, out hitInfo, Quaternion.identity
            , Owner.BaseAtt.RoleInfo.fJumpHeight - SBoxSize + 0.1f, BoxMask))
        {
            return false;
        }
        else
        {
            RayCastBlock();

            if (m_bIsBlocked)
                return true;
        }

        return true;
    }

    void JumpDownBehaviour()                                                                                      //处理角色下跳行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)
        {
            if (fOrigHeight - Owner.ActorTrans.position.y >= Owner.ActorHeight && m_bIsDescent == true && JumpThroughState == true)
            {
                JumpThroughState = false;
                return;
            }
        }
    }

    public void JumpBehaviour()                                                                                     //处理角色跳跃行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            //if (m_fCurSpeed <= 0f && m_bIsDescent == false)
            if (Owner.Velocity.y <= 0f && m_bIsDescent == false)
            {
                m_bIsDescent = true;
                JumpThroughState = false;
            }
            //如果在下降，需要判断玩家是否在空中会撞到brick。如果撞到，那么需要将他变成运动学刚体
            if (m_bIsDescent && JumpThroughState == false)
            {
                if (Physics.BoxCast(Owner.ActorTrans.position + Owner.BC.center, new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f, 0.1f),
                                      Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BrickMask)) {
                                              m_tDescent = hitInfo.transform;
                                              JumpThroughState = true;
                }
            }
            else if (m_bIsDescent && JumpThroughState == true && null != m_tDescent)
            {
                if (m_tDescent.position.y - Owner.ActorTrans.position.y >= Owner.ActorHeight)
                 {
                    JumpThroughState = false;
                 }
            }
            else if (!m_bIsDescent)
            {
                SetPlayerUpKinematic(); //设置玩家是否可以向上穿越障碍.
            }

            //CalCharacterJump();

        }
    }

    void SetJumpDownState(Collision other)                                                                      //设置角色下跳权限
    {
#if UNITY_EDITOR
        //Debug.Log("SetJumpDownState -> name : " + other.transform.name);
#endif
        m_bGounded = true;
        m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;
        Owner.Velocity = Vector3.zero;
        m_bIsDescent = false;
        if (other.gameObject.layer == BrickMaskGlossy)
            BCanJumpDown = ePlayerJumpDownState.CanJumpDown_YES;
        else if (other.gameObject.layer == MaskGlossy || other.gameObject.layer == BoxMaskGlossy)
            BCanJumpDown = ePlayerJumpDownState.CanJumpDown_NO;
    }
    
    bool bUp = false;
    bool bUpForward = false;
    float m_fUpDisForBrick;
    float m_fBiasDisForBrick;//
   
    void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //if (null != hitInfo.transform)
        //Gizmos.DrawLine(Owner.ActorTrans.position + Vector3.up * Owner.ActorHeight * 0.5f, hitInfo.transform.position);

        //Gizmos.DrawSphere(Owner.ActorTrans.position + Vector3.up * Owner.ActorHeight * 0.5f, 0.55f);
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(LookTarget, 0.4f);
        tmpx = 1;
        if (m_vInputMove.x == 0f)
        {
            tmpx = lastTmpx;
        }
        else if (m_vInputMove.x < 0f)
            tmpx = -1;


        //RaycastHit[] hits = Physics.BoxCastAll(pos, new Vector3(0.1f, Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f), Owner.ActorTrans.forward, Quaternion.Euler(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BoxMask);


        ExtDebug.DrawBoxCastBox(
        Owner.ActorTrans.position + Owner.BC.center,
        new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f, 0.1f),
        Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorTrans.forward, Owner.ActorHeight * 0.5f + 0.2f, Color.green
        );

        //if (Physics.BoxCast(Owner.ActorTrans.position + Owner.BC.center, new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f, 0.1f),
        //                          Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BrickMask))
        //{
        //    m_tDescent = hitInfo.transform;
        //    Owner.BC.isTrigger = true;
        //}


        //tmpx = 1;
        //if (m_vInputMove.x == 0f)
        //{
        //    tmpx = lastTmpx;
        //}
        //else if (m_vInputMove.x < 0f)
        //    tmpx = -1;


        //ExtDebug.DrawBoxCastBox(
        //Owner.ActorTrans.position + Vector3.up * 0.44f,
        //new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
        //Quaternion.identity, new Vector3(0f, 1f, 0f), m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f, Color.green
        //);

        //if (Physics.BoxCast(Owner.ActorTrans.position + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out hitInfo, Quaternion.Euler(Vector3.up),
        //    m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f, BoxMask))
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawCube(hitInfo.point, 0.1f * Vector3.one);
        //}

        //Debug.DrawLine(Owner.ActorTrans.position + Vector3.up * 0.44f, 
        //                           Owner.ActorTrans.position + Vector3.up * 0.44f + Vector3.up * (m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f), Color.green);


        //if (m_vInputMove.x == 0f)
        //    return;

        //ExtDebug.DrawBoxCastBox(
        //Owner.ActorTrans.position - Owner.BC.size.x * 0.5f * Vector3.right * tmpx + Vector3.up * 0.44f,
        //new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
        //Quaternion.LookRotation((new Vector3(tmpx * -1f, 1f, 0f)).normalized), new Vector3(tmpx * 1f, 1f, 0f), m_fBiasDisForBrick * 2f, Color.red
        //);

        //Gizmos.color = Color.red;
        //RaycastHit[] hits = Physics.BoxCastAll(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
        //                                                                            Vector3.up + Vector3.right * tmpx, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick * 2f, BoxMask);

        //for (int i = 0; i < hits.Length; i++)
        //{
        //    Gizmos.DrawSphere(hits[i].point, 0.1f);
        //}
        //Debug.DrawLine(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f,
        //    Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f + (Vector3.up + Vector3.right * tmpx) * (2*m_fBiasDisForBrick),
        //    Color.red);

        //lastTmpx = tmpx;

    }

    void FreeFall()
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && Owner.Velocity.y < -0.2f)
        {
            DoBeforeJump(ePlayerNormalBeha.eNormalBehav_JumpDown, -1f, true);
        }
    }
    void DoBeforeJump(ePlayerNormalBeha type, float InitSpeed, bool isDescent)                   //jump前的数据准备
    {
        m_tDescent = null;
        if (type == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            m_fStartTime = Time.time;
            Owner.Velocity = new Vector3(0f, InitSpeed, 0f);
            AudioManager.PlayAudio(Owner.gameObject, eAudioType.Audio_Skill, "JumpUp");
        }
        m_ePlayerNormalBehav = type;
        fOrigHeight  = Owner.ActorTrans.transform.position.y;
        m_bIsDescent = isDescent;
       
    }

    float tmpx = 1f;
    float lastTmpx = 1f;
    readonly float fCheckJumpTime = 0.04f;

    bool JumpThroughState
    {
        get
        {
            return Owner.BC.isTrigger;
        }
        set
        {
            if (value != Owner.BC.isTrigger)
                Owner.BC.isTrigger = value;
        }
    }

    void SetPlayerUpKinematic()
    {
        if (JumpThroughState == false && Time.time - m_fStartTime >= fCheckJumpTime) //0.04 通过计算可以让角色跳跃0.44米高度, 角色头顶和brick的距离是0.5f。
        {
            if (Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out hitInfo, Quaternion.Euler(Vector3.up), 0.1f + Owner.ActorHeight, BrickMask))                            
            {
                //检测上方是否有box
                if (!Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out hitInfo, Quaternion.Euler(Vector3.up),
                   Owner.BaseAtt.RoleInfo.fJumpHeight + SBoxSize + 0.1f,
                    BoxMask))                                  
                    {
                        JumpThroughState = true;
                    }
            }
        }
    }

    #endregion

    #region 贝塞尔曲线 寻路
    sStellerCatMull m_sStellerCat;
    int WayFindingMaskGlossy;
    int WayFinidngMask;
    float PathPercent;
    float Length = 2f;
    float LookAheadAmount = 0.01f;
    Vector3 floorPosition;
    float min = 0f;
    Transform PahtAreaCtrl;                         //寻路点管理对象
    PathArea CurArea;                                 //当前所在区域
    PathArea NextArea;
    Transform[] ArrtTPoints;                         //当前路线点

    bool bPass = false;
    float pathPosition = 0;

    void ResetpathPosition()
    {
        if(pathPosition<0)
        {
            pathPosition = 0;
        }
        if (pathPosition >= 1)
            pathPosition = 1;
    }

    public void RotatePlayerAlongBezier()
    {
        #region 进度
        //切线，朝向
        Vector3 dir = BezierLine.GetVelocity(PathPercent, ArrtTPoints.Length);
        #region 根据输入计算进度
        if (m_vInputMove.x > 0f)
        {
            // m_fCurPercent = m_fCurPercent +( 1f *Time.deltaTime)/ GetVelocity(m_fCurPercent).magnitude;
            PathPercent = PathPercent + (Length * Time.deltaTime) / dir.magnitude;
            // pathPosition += Time.deltaTime * PathSpeed;
        }
        else if (m_vInputMove.x < 0f)
        {
            PathPercent = PathPercent - (Length * Time.deltaTime) / dir.magnitude;
        }
        #endregion


        #endregion

//        #region 确定线路
//        int length = CurArea.RoutePoints.Length;
//        //到达倒数第二点的临界位置的比
//        float ChangPercent = Vector3.Distance(ArrtTPoints[length - 2].transform.position, ArrtTPoints[0].transform.position) / Vector3.Distance(ArrtTPoints[length - 1].transform.position ,ArrtTPoints[0].transform.position);
//        if (PathPercent >= ChangPercent-0.01f && !bPass)
//        {
//            bPass = true;
//            //新区域的进度值归零
//            PathPercent = 0;
//            //下一个区域
//            NextArea = CurArea.NextAreas[0];
//            //下一个区域的长度
//            int n = NextArea.RoutePoints.Length;
//            //新的路线确定，起点为旧路线的最后一个点
//            ArrtTPoints = new Transform[n + 2];
//            ArrtTPoints[0] = CurArea.RoutePoints[length - 2];
//            ArrtTPoints[1] = CurArea.RoutePoints[length - 1];

//            for (int i = 0; i < NextArea.RoutePoints.Length; i++)
//            {
//                ArrtTPoints[2 + i] = NextArea.RoutePoints[i];
//            }
//            BezierLine.GetBezierPoints(ArrtTPoints);
//            CurArea = NextArea;
//            return;
//        }
//#endregion

        #region 控制朝向
        //如果进度在合法范围内
        if (PathPercent - LookAheadAmount >= float.Epsilon && PathPercent + LookAheadAmount <= 1f)
        {
            #region 计算朝向
           
            Debug.Log(dir * Time.deltaTime);
            Vector3 m_vOwnerPosition = Owner.ActorTrans.position;
            if (m_vInputMove.x > 0f)
            {
                Owner.ActorTrans.LookAt2D(m_vOwnerPosition+dir.normalized);
            }
            else if (m_vInputMove.x < 0f)
            {
                Owner.ActorTrans.LookAt2D(m_vOwnerPosition -dir.normalized);
            }
            #endregion
        }
       #endregion

        #region 计算角色偏移
        floorPosition = BezierLine.GwtMove(PathPercent, ArrtTPoints.Length);
        //Owner.ActorTrans.position = Vector3.Lerp(Owner.ActorTrans.position, new Vector3(
        //    floorPosition.x,
        //    Owner.ActorTrans.position.y,
        //    floorPosition.z
        //    ), SMoveSpeed*Time.deltaTime );
        Owner.ActorTrans.position = new Vector3(
            floorPosition.x,
            Owner.ActorTrans.position.y,
            floorPosition.z
            );

        #endregion

        //当到达终点位置的时候限制人物的位置
        //if (PathPercent >= 0.99f)
        //{
        //    // Owner.ActorTrans.position = new Vector3(
        //    // ArrtTPoints[ArrtTPoints.Length - 1].transform.position.x,
        //    // Owner.ActorTrans.position.y,
        //    //ArrtTPoints[ArrtTPoints.Length - 1].transform.position.z
        //    // );
        //    Time.timeScale = 0;
        //}

    }

    #endregion

    #region Translate

    public bool RayCastBlock()
    {
        if (Physics.BoxCast(Owner.ActorTrans.position + Owner.BC.center, new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.4f, 0.1f),
                                        Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f, BoxMask + WallMask
            )
         )
        {
            m_bIsBlocked = true;
        }
        return m_bIsBlocked;
    }

    void TranslatePlayer()
    {
        //if(m_vInputMove.x != 0f)
        //    Owner.ActorTrans.Translate(new Vector3(0f, 0f,  Mathf.Abs(m_vInputMove.x) * SMoveSpeed * Time.deltaTime));
    }

    public bool CheckMoveBoundaryBlock(float extra = 0f) 
    {
        if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
        {
            if (m_vInputMove.x == 0f)
                return false;
        }
       
        if (cc.CamMoveDir == eCamMoveDir.CamMove_Right)
        {
            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Left].x + Owner.ActorSize - extra && m_vInputMove.x < 0f) 
                return true;//block left
        }
        else if (cc.CamMoveDir == eCamMoveDir.CamMove_Left)
        {
            if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Right].x - Owner.ActorSize + extra && m_vInputMove.x > 0f) 
                return true; //block right
        }
        else if (cc.CamMoveDir == eCamMoveDir.CamMove_Up)
        {
            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Left].x + Owner.ActorSize - extra && m_vInputMove.x < 0f) 
                return true;//block left
            else if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Right].x - Owner.ActorSize + extra && m_vInputMove.x > 0f) 
                return true; //block right
        }
    
        return false; 
    }

    void PlayMoveAnim()
    {
        if(0f == m_vInputMove.x)
            Owner.AM.SetFloat(NameToHashScript.SpeedId, 0f);
        else
        {
            Owner.AM.SetFloat(NameToHashScript.SpeedId, 1f);
        }
    }
    #endregion
  
    #region 通用接口

    void ResetAllData()
    {
        m_bIsBlocked = false;
        m_bCollisionEntered = false;
    }
    #endregion

    #region 非主角NPC状态机驱动接口

        RoleInfos m_RoleInfos; 
        public void StateUpdate()           
        {   
            if (Owner.BaseAtt.RoleInfo.CharacType == eCharacType.Type_Major)
                return;

            if(null == m_RoleInfos)
                m_RoleInfos = Owner.BaseAtt.RoleInfo;

            switch (m_RoleInfos.MonsterType)
            {
                case eMonsterType.MonType_GroundNpc:
                    {
                        switch (m_RoleInfos.MoveType)
                        {
                            case eMoveType.eMove_Straight:                          //地面怪兽，直线行走
                                {
                                    GoundMonsterStraight();
                                    break;
                                }
                            case eMoveType.eMove_Track:                             //面怪兽，追击主角
                                {
                                    break;
                                }
                        }
                        break;
                    }
                case eMonsterType.MonType_FlyBat:
                    {
                 
                        break;
                    }
            }

            //执行小跳跃
            JumpBehaviour();

            //自由下落
            FreeFall();

            //执行下跳操作
            JumpDownBehaviour();

            //复位数据
            ResetAllData();
        }

        int n;
        void GoundMonsterStraight()
        {
            //判定是否走出了视野范围

            if (CheckMoveBoundaryBlock(Owner.ActorHeight))
            {
                Destroy(transform.parent.gameObject);
                return;
            }

            RotatePlayerAlongBezier();

            m_vInputMove = transform.forward;

            PlayMoveAnim();

            //判断是否可以前进
            //返回true ： 则表示前方有box
            //返回false :   表示可以前进
            if (Physics.BoxCast(Owner.ActorTrans.position + Owner.BC.center, new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.4f, 0.1f),
                                     Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f, BoxMask + WallMask))
            {
                m_bIsBlocked = true;

                if (hitInfo.collider.gameObject.layer == WallMaskGlossy)
                {
                    m_vInputMove.x = 0 - m_vInputMove.x;
                }
                else
                {
                    /*
              * 怪兽有可能有三种行为
              * 1 : 跳过盒子
              * 2 : 举起盒子
              * 3 : 朝着反方向运动
              * 
              * 如果举着盒子，当和主角满足一定条件，那么扔掉盒子，否则一直举着盒子
              * 
              * */
                    n = UnityEngine.Random.Range(0, 100);

                    //m_vInputMove.x = 0 - m_vInputMove.x;
                    //return;
                    if (n > 70 )             //跳过盒子
                    {
                        CalJumpUp();
                    }
                    else if (n <= 70 && n > 30 && m_bIsHoldBox == false && null == m_bcCurBox)                     //举起盒子
                    {
                        SkillMgr.UseSkill(eSkillType.SkillType_ThrowBox);
                    }
                    else                                                        //朝着反方向行走
                    {
                        m_vInputMove.x = 0 - m_vInputMove.x;
                    }
                }
            }
            else
            {
                TranslatePlayer();
            }
        }

    #endregion

}

//#region Pick up box, Throw box, Destroy box

//void DestroyBox()
//{
//    Destroy(m_bcCurBox);
//    m_bcCurBox = null;
//}

//void DoBeforePickUpBox()
//{
//    m_bcCurBox.gameObject.layer = HoldBoxMaskGlossy;
//    m_bcCurBox.isTrigger = true;                                                                                            //将盒子变成触发器           
//    float radius = m_bcCurBox.size.y + Owner.ActorHeight * 0.5f ;                             //确认运动半径
//    m_bcCurBox.transform.parent = Owner.ActorTrans.transform;                                          //将盒子变成主角的孩子
//    m_bIsHoldBox = true;                                                                                                       //标识当前是举着箱子的状态
//    StartCoroutine(PickUpBoxBehaviour(radius));                                                                             //播放举箱子动画
//}

//IEnumerator PickUpBoxBehaviour(float radius)
//{
//    //盒子繞著指定的半徑，圍繞主角做圓周運動
//    while (m_bcCurBox.transform.localPosition.y < radius - 0.1f)
//    {
//        m_bcCurBox.transform.localPosition = Vector3.Lerp(m_bcCurBox.transform.localPosition, new Vector3(0f, radius, 0f), 30 * Time.deltaTime);

//         yield return null;
//    }

//    m_bcCurBox.gameObject.transform.localRotation = Quaternion.identity;

//}

//#endregion
//    public bool CalPickUpBox()
//    {

//            if (m_bIsHoldBox == false && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide && m_vInputMove.x != 0f && null == m_bcCurBox)
//            {
//                float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;
//                pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

//                //拿到所有的盒子，然后判定盒子位置最低的<判定的依据，做多有两个盒子> todo_erric ： 如何有多个盒子，或者尺寸出现了变化，那么就无法判定了
//                RaycastHit[] hits = Physics.BoxCastAll(pos, new Vector3 (0.1f, Owner.ActorHeight * 0.4f, Owner.ActorHeight * 0.5f), Owner.ActorTrans.forward, Quaternion.Euler (Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BoxMask);
//                if (hits.Length > 0)
//                {
//                    if (hits.Length > 1)
//                        m_bcCurBox = (hits[0].transform.position.y > hits[1].transform.position.y ? (BoxCollider)(hits[1].collider) : (BoxCollider)(hits[0].collider));
//                    else
//                        m_bcCurBox = (BoxCollider)(hits[0].collider);
//#if UNITY_EDITOR
//                    Debug.Log("Successfully Pick up the Box");
//#endif
//                    DoBeforePickUpBox();
//                    return true;
//                }
//                else
//                {
//#if UNITY_EDITOR
//                    Debug.Log("Fail to pick up the box");
//#endif
//                }
//            }
//            else if (m_bIsHoldBox == true && m_bcCurBox != null && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide)
//            {
//                m_bIsHoldBox = false;                                                                                               //复位托举状态
//                m_bcCurBox.transform.parent = null;                                                                        // 将箱子的父亲设置为空
//                BoxController boxCon = m_bcCurBox.transform.GetComponent<BoxController>();   // 启动箱子的运动
//                boxCon.OnStart();
//                m_bcCurBox = null;                                                                                                  //这样接下来就可以在举箱子
//                return true;
//            }
//        return false;
//    }
