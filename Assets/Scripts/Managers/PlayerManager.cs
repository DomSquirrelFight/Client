using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System.Linq;
using Assets.Scripts.Helper;
public class PlayerManager : MonoBehaviour
{

    #region 变量
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

    int HoldBoxMask;

    JumpDataStore m_curJumpData;                                                                                                                                 //跳跃数据

    float TmpDis;                                                                                                                                                               //保存临时变量

    RaycastHit hitInfo;                                                                                                                                                       //射线检测数据

    Vector3 m_vCurForward;                                                                                                                                             //保存当前角色朝向

    bool m_bIsBlocked = false;                                                                                                                                         //判定横向是否被盒子阻挡了

    BoxCollider m_bcCurBox = null;
    bool m_bIsHoldBox = false;
    float m_fPlayerBoxRaidus = 0f;


    public float FPlayerJumpBeginYPos                                                                                                                            //角色起跳在Y轴方向的高度值
    {
        get
        {
            return fOrigHeight;
        }
    }

    bool m_bCanJumpDown = false;
    bool BCanJumpDown
    {
        get
        {
            return m_bCanJumpDown;
        }
        set
        {
            if (value != m_bCanJumpDown)
                m_bCanJumpDown = value;
        }
    }                                                                                                                                              //是否可以下跳

    float fOrigHeight = 0f;                                                                                                         //开始跳跃或者下降前的高度

    float m_curHeight = 0f;                                                                                                       //保存角色当前高度

    bool m_bIsDescent = false;                                                                                                  //判断是否在下降
    
    float curspeed = 0f;
    float m_fCurSpeed                                                                                                     //获取当前的速度
    {
        get {
            return curspeed;
        }
        set
        {
            if (value != curspeed)
                curspeed = value;
        }
    }
    float m_fStartTime = 0f;                                                                                                      //跳跃开始前的计时变量

    float m_fDuration = 0;                                                                                                        //保存跳跃的时长

    float m_fInitSpeed = 0f;

    Vector2 m_vInputMove;                                                   //发送平移输入

    UIScene_Fight m_UISceneFight;

    #endregion

    #region 外部接口 / 系统接口
    public void OnStart(BaseActor owner)
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

        Owner = owner;
        m_UISceneFight = Helpers.UIScene<UIScene_Fight>();
        m_UISceneFight.OnStart(Owner);
        cc = Owner.CameraContrl;
        m_curJumpData = Owner.SmallJumpDataStore;

        //角色垂直上跳，碰到brick的距离
        m_fUpDisForBrick = m_curJumpData.m_fJumpHeight - 0.2f - Owner.ActorHeight + 0.1f;

        float tmp = m_curJumpData.m_fJumpHeight + 0.1f;
        float dis = Mathf.Sqrt(tmp * tmp * 2);
        //float halfDiagonal = Mathf.Sqrt(Owner.ActorHeight * Owner.ActorHeight * 2) * 0.5f;
        m_fBiasDisForBrick = dis;// -halfDiagonal + 0.1f;
        //CalculateSlideDis();
    }


    void Update()
    {
        if (!Owner)
            return;

        CalMoveInput();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K))
                CalJump();

            if (Input.GetKeyDown(KeyCode.U))
                CalPickUpBox();
        }

        //执行旋转操作
        RotatePlayer();
        //播放位移动画
        PlayMoveAnim();
        if (0f != m_vInputMove.x)
        {
            if (!CheckMoveBoundaryBlock())//判定横向是否超出朝向边界
            {
                if (!RayCastBlock())//横向阻挡
                {
                    //执行move操作
                    TranslatePlayer();
                }
            }
        }

        //执行小跳跃
        JumpBehaviour();

        //执行下跳操作
        JumpDownBehaviour();

        //复位数据
        ResetAllData();

    }

    //void FixedUpdate()
    //{
    //    if (!Owner)
    //        return;

    //    //执行旋转操作
    //    RotatePlayer();
    //    //播放位移动画
    //    PlayMoveAnim();
    //    if (0f != m_vInputMove.x)
    //    {
    //        if (!CheckMoveBoundaryBlock())//判定横向是否超出朝向边界
    //        {
    //            if (!RayCastBlock())//横向阻挡
    //            {
    //                //执行move操作
    //                TranslatePlayer();
    //            }
    //        }
    //    }

    //    //执行小跳跃
    //    JumpBehaviour();

    //    //执行下跳操作
    //    JumpDownBehaviour();

    //    //复位数据
    //    ResetAllData();
    //}
  

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
            ve = Input.GetAxis("Vertical");
            if (0f == he && 0f == ve && (m_UISceneFight))
            {
                m_vInputMove = m_UISceneFight.DirPos; //否则 用摇杆数据
            }
            else if (0f != he || 0f != ve)
            {
                m_vInputMove.x = he;
                m_vInputMove.y = ve;
            }
        }

        if (m_vInputMove.y < GlobalHelper.SJumpDownVertical) //如果按了下，那么将无法横向位移
        {
            m_vInputMove.x = 0f;
        }
    }

    bool CalJumpUp()                                              //获取跳跃输入
    {
        if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && m_vInputMove.y > GlobalHelper.SJumpDownVertical)
        {
                DoBeforeJump(ePlayerNormalBeha.eNormalBehav_SmallJump, m_curJumpData.m_fJumpInitSpeed, false);
                return true;
        }
        return false;
    }

    bool CalJumpDown()
    {

            if (!CheckJumpDown())                   //检查下落的下方是否有盒子.
            {
                return false;
            }

            if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && BCanJumpDown == true)
            {
#if UNITY_EDITOR
                Debug.Log("Can jump down");
#endif
    
                Owner.RB.isKinematic = true;
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

    public void CalJump()
    {
        if (m_vInputMove.y <= GlobalHelper.SJumpDownVertical)
        {
            CalJumpDown();
        }
        else
            CalJumpUp();
    }

    RaycastHit m_HitInfo;
    Vector3 pos;

    public bool CalPickUpBox()
    {

            if (m_bIsHoldBox == false && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide && m_vInputMove.x != 0f && null == m_bcCurBox)
            {

                float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;
                pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

                //拿到所有的盒子，然后判定盒子位置最低的
                RaycastHit[] hits = Physics.BoxCastAll(pos, new Vector3 (0.1f, Owner.ActorHeight * 0.4f, Owner.ActorHeight * 0.5f), Owner.ActorTrans.forward, Quaternion.Euler (Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BoxMask);
                if (hits.Length > 0)
                {
                    if (hits.Length > 1)
                        m_bcCurBox = (hits[0].transform.position.y > hits[1].transform.position.y ? (BoxCollider)(hits[1].collider) : (BoxCollider)(hits[0].collider));
                    else
                        m_bcCurBox = (BoxCollider)(hits[0].collider);
#if UNITY_EDITOR
                    Debug.Log("Successfully Pick up the Box");
#endif
                    DoBeforePickUpBox();
                    return true;
                }
                else
                {
#if UNITY_EDITOR
                    Debug.Log("Fail to pick up the box");
#endif
                }
            }
            else if (m_bIsHoldBox == true && m_bcCurBox != null && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide)
            {
                m_bIsHoldBox = false;                                                                                               //复位托举状态
                m_bcCurBox.transform.parent = null;                                                                        // 将箱子的父亲设置为空
                BoxController boxCon = m_bcCurBox.transform.GetComponent<BoxController>();   // 启动箱子的运动
                boxCon.OnStart();
                m_bcCurBox = null;                  //这样接下来就可以在举箱子
                return true;
            }
        return false;
    }

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
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (m_bCollisionEntered == false)
            OnCollisionEnter(other);
    }


    //void OnCollisionStay(Collision other)
    //{

    //    if (other.contacts.Length > 0)
    //    {
    //        if (other.contacts[0].thisCollider.gameObject.layer == NpcMaskGlossy)                                    //角色碰到了ground, brick or box
    //        {
               
    //            if (other.contacts[0].otherCollider.gameObject.layer == BoxMaskGlossy)                              //如果判定碰到的是box
    //            {
    //                OperateGround(other, BoxMask);
    //            }
    //            else if (other.contacts[0].otherCollider.gameObject.layer == BrickMaskGlossy)                                           //如果判定接触到的是brick
    //            {
    //                OperateGround(other, BrickMask);
    //            }
    //            //else if (other.contacts[0].otherCollider.gameObject.layer == MaskGlossy)
    //            //{
    //            //    if (m_bIsDescent)
    //            //    {
    //            //        //if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)
    //            //        //{
    //            //        //    Debug.Log("Jump down grounded");
    //            //        //}
                            
    //            //        SetJumpDownState(other);
    //            //    }
    //            //}
    //        }
    //    }
    //}

    void OperateGround(Collision other, int layer)                                //处理落地逻辑
    {
        float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;

        pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

        if (Physics.SphereCast(pos, GlobalHelper.SBoxSize * 0.5f, Vector3.down, out hitInfo, Owner.ActorHeight * 0.5f + 0.1f, layer))     //如果在角色垂直向下方向射到了box，那么处理落地逻辑
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
        else if (Physics.SphereCast(pos, GlobalHelper.SBoxSize * 0.5f, Vector3.up, out hitInfo, Owner.ActorHeight * 0.5f + 0.1f, layer))
        {
            if (hitInfo.collider.gameObject == other.collider.gameObject && m_bIsDescent == false)//在上升过程中
            {
#if UNITY_EDITOR
                if(layer == mask)
                    Debug.Log(1);
#endif
                Owner.RB.velocity = Vector3.zero;
                m_fCurSpeed = 0f;
            }

        }
    }

    #endregion
 
    #region Jump
    Transform m_tDescent;
    bool CheckJumpDown()                                                 //解决在下跳的时候，下一层有很多的盒子，导致角色不能完全跳下去，而卡在两个层中间
    {

        //检测到了下面有box
        if (Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.4f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.down, out m_rayCheckJumpBrick, Quaternion.identity
            , m_curJumpData.m_fJumpHeight - GlobalHelper.SBoxSize + 0.1f, BoxMask))
        {
            return false;
        }
        else
        {

            RayCastBlock();

            if (m_bIsBlocked)
                return true;
            if(m_vInputMove.x == 0f)
            {
                return true;
            }
            else if (m_vInputMove.x > 0f)
            {
                tmpx = 1f;
            }
            else  if (Owner.ActorTrans.forward.x < 0f)
                tmpx = -1;
            if (Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.down + Vector3.right * tmpx, out m_rayCheckJumpBrick, Quaternion.LookRotation((new Vector3(tmpx * -1, -1, 0)).normalized), m_fBiasDisForBrick, BoxMask))
            {
                return false;
            }
        }

        return true;
    }

    void JumpDownBehaviour()                                                                                      //处理角色下跳行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)
        {
            if (fOrigHeight - m_curHeight >= Owner.ActorHeight && m_bIsDescent == true && Owner.RB.isKinematic == true)
            {
                Owner.RB.isKinematic = false;
                Owner.RB.velocity = new Vector3(0f, m_fCurSpeed, 0f);
                return;
            }
            CalCharacterJump();
        }
    }

    public void JumpBehaviour()                                                                                     //处理角色跳跃行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            if (m_fCurSpeed <= 0f && m_bIsDescent == false)
            {
                m_bIsDescent = true;
                Owner.RB.isKinematic = false;
                m_fCurSpeed = Owner.RB.velocity.y;
                //Owner.RB.velocity = new Vector3(0f, 0f, 0f);//将物体速度归0。
                //return;
            }
            //如果在下降，需要判断玩家是否在空中会撞到brick。如果撞到，那么需要将他变成运动学刚体
            if (m_bIsDescent && Owner.BC.isTrigger == false)
            {
                if (Physics.BoxCast(Owner.ActorTrans.position + Owner.BC.center, new Vector3(Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f, 0.1f),
                                      Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BrickMask)) {
                                              m_tDescent = hitInfo.transform;
                                              Owner.BC.isTrigger = true;
                }
            }
            else if (m_bIsDescent && Owner.BC.isTrigger == true && null != m_tDescent)
            {
                if (m_tDescent.position.y - Owner.ActorTrans.position.y >= Owner.ActorHeight)
                 {
                     Owner.BC.isTrigger = false;
                     //Owner.RB.velocity = new Vector3(0f, m_fCurSpeed, 0f);
                 }
            }
            else if (!m_bIsDescent)
            {
                SetPlayerUpKinematic(); //设置玩家是否可以向上穿越障碍.
            }

            CalCharacterJump();

        }
    }

    void SetJumpDownState(Collision other)                                                                      //设置角色下跳权限
    {
#if UNITY_EDITOR
        Debug.Log("SetJumpDownState -> name : " + other.transform.name);
#endif
        m_bGounded = true;
        m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;
        Owner.RB.velocity = Vector3.zero;
        m_fCurSpeed = 0f;
        m_bIsDescent = false;
        if (other.gameObject.layer == BrickMaskGlossy)
            BCanJumpDown = true;
        else if (other.gameObject.layer == MaskGlossy || other.gameObject.layer == BoxMaskGlossy)
            BCanJumpDown = false;
    }
    
    bool bUp = false;
    bool bUpForward = false;
    RaycastHit m_rayCheckJumpBrick;//用来检测开始上跳时，上方是否有brick
    float m_fUpDisForBrick;
    float m_fBiasDisForBrick;//
   
    void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //if (null != hitInfo.transform)
        //Gizmos.DrawLine(Owner.ActorTrans.position + Vector3.up * Owner.ActorHeight * 0.5f, hitInfo.transform.position);

        //Gizmos.DrawSphere(Owner.ActorTrans.position + Vector3.up * Owner.ActorHeight * 0.5f, 0.55f);

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

        //if (Physics.BoxCast(Owner.ActorTrans.position + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out m_rayCheckJumpBrick, Quaternion.Euler(Vector3.up),
        //    m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f, BoxMask))
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawCube(m_rayCheckJumpBrick.point, 0.1f * Vector3.one);
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

    void DoBeforeJump(ePlayerNormalBeha type, float InitSpeed, bool isDescent)                   //jump前的数据准备
    {
        //float t = 0.04f;
        //float a = 12f * t - 20f * t * t;
        m_tDescent = null;
        Owner.RB.velocity = new Vector3(0f, InitSpeed, 0f);
        m_ePlayerNormalBehav = type;
        fOrigHeight = m_curHeight = Owner.ActorTrans.transform.position.y;
        m_bIsDescent = isDescent;
        m_fCurSpeed = m_fInitSpeed = InitSpeed;
        m_fStartTime = Time.time;

        //找到brick，然后计算fCheckJumpTime

        //检测上方，前后和后方是否有brick, 
    }

    float tmpx = 1f;
    float lastTmpx = 1f;
    readonly float fCheckJumpTime = 0.04f;
    //float m_fSlideDis = 0f;
    //void CalculateSlideDis () {
    //                            float v0 = m_curJumpData.m_fJumpInitSpeed + 0.5f * m_curJumpData.m_fJumpAccel * fCheckJumpTime;
    //                            float a = 0.5f * m_curJumpData.m_fJumpAccel;
    //                            float b = v0;
    //                            float c = 0f - 0.26f;

    //                            float upright = Mathf.Sqrt(b * b - 4f * a * c);
    //                            float upleft = 0 - b;
    //                            float down = 2f * a;


    //                            float t1 = (upleft - upright) / down;
    //                            float t2 = (upleft + upright) / down;

    //                            float t = t1 < t2 ? t1 : t2;
    //                            if (t < 0f)
    //                            {
    //                                Debug.LogErrorFormat("t1 = {0}, t2 = {1}", t1, t2);
    //                                return;
    //                            }
    //                            m_fSlideDis = GlobalHelper.SMoveSpeed * t;
    //}

    void SetPlayerUpKinematic()
    {
        if (Owner.RB.isKinematic == false && Time.time - m_fStartTime >= fCheckJumpTime) //0.04 通过计算可以让角色跳跃0.44米高度, 角色头顶和brick的距离是0.5f。
        {
            if (Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out m_rayCheckJumpBrick, Quaternion.Euler(Vector3.up), 0.1f + Owner.ActorHeight, BrickMask))                               
            {
                //检测上方是否有box
                if (!Physics.BoxCast(Owner.ActorTrans.position, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out m_rayCheckJumpBrick, Quaternion.Euler(Vector3.up), 
                    m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f,
                    BoxMask))                                  
                    {
                        Owner.RB.isKinematic = true;
                        //if (m_vInputMove.x == 0f)
                        //{
                        //    Owner.RB.isKinematic = true;
                        //    return;
                        //}
                        
                        //tmpx = 1f;
                        //if (Owner.ActorTrans.forward.x < 0f)
                        //    tmpx = -1;
                        //if (!Physics.BoxCast(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up + Vector3.right * tmpx, out m_rayCheckJumpBrick, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick, BoxMask)) 
                        //{
                        //    Owner.RB.isKinematic = true;
                        //    return;
                        //}
                        //else
                        //{

                        //    float s1 = Mathf.Abs(m_rayCheckJumpBrick.transform.position.x - Owner.ActorTrans.position.x) - Owner.ActorHeight * 0.5f - GlobalHelper.SBoxSize * 0.5f;
                        //    if (s1 > m_fSlideDis)
                        //    {
                        //        Owner.RB.isKinematic = true;
                        //    }
                        //}  
                    }
            }
        }
    }

    void CalCharacterJump()                                                                         //计算角色位移<运动学刚体>
    {

        m_fDuration = Time.time - m_fStartTime;

        if (Owner.RB.isKinematic == false)
        {
            m_fCurSpeed = Owner.RB.velocity.y;
            m_curHeight = Owner.ActorTrans.transform.position.y;
        }
        else
        {
            m_fCurSpeed = m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration);
            m_curHeight = fOrigHeight + (m_fInitSpeed * m_fDuration + 0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);
      
            Owner.ActorTrans.transform.position = new Vector3(
              Owner.ActorTrans.transform.position.x,
              m_curHeight,
              Owner.ActorTrans.transform.position.z
              );

        }

      

       
    }
    //void CalCharacterJump()                                                                         //计算角色位移<运动学刚体>
    //{
    //    Owner.ActorTrans.transform.position = new Vector3(
    //           Owner.ActorTrans.transform.position.x,
    //           m_curHeight,
    //           Owner.ActorTrans.transform.position.z
    //           );
    //    m_fDuration = Time.time - m_fStartTime;
    //    if(Owner.RB.isKinematic == false) {
    //          Owner.RB.velocity = new Vector3(0f, m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration), 0f);
    //          m_fCurSpeed = Owner.RB.velocity.y;
    //    }
    //    else {
    //        m_fCurSpeed = m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration);
    //    }
        
      
    //    m_curHeight = fOrigHeight + (m_fInitSpeed * m_fDuration + 0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);
    //}
   
    #endregion

    #region Translate
    bool RayCastBlock()
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

    void RotatePlayer()
    {
        if (m_vInputMove.x != 0f)
        {
            m_vCurForward = new Vector3(m_vInputMove.x, 0f, 0f);
            Owner.ActorTrans.forward = Vector3.Lerp(Owner.ActorTrans.forward, m_vCurForward, GlobalHelper.SRotSpeed * Time.deltaTime);
        }
    }

    void TranslatePlayer()
    {
        if(m_vInputMove.x != 0f)
            Owner.ActorTrans.Translate(new Vector3(0f, 0f,  Mathf.Abs(m_vInputMove.x) * GlobalHelper.SMoveSpeed * Time.deltaTime));
    }

    bool CheckMoveBoundaryBlock() 
    {

        if (m_vInputMove.x == 0f)
            return false;

        if (cc.CamMoveDir == eCamMoveDir.CamMove_Right)
        {
            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Left].x + Owner.ActorSize && m_vInputMove.x < 0f) return true;//block left
        }
        else if (cc.CamMoveDir == eCamMoveDir.CamMove_Left)
        {
            if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Right].x - Owner.ActorSize && m_vInputMove.x > 0f) return true; //block right
        }
        else if (cc.CamMoveDir == eCamMoveDir.CamMove_Up)
        {
            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Left].x + Owner.ActorSize && m_vInputMove.x < 0f) return true;//block left
            else if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Right].x - Owner.ActorSize && m_vInputMove.x > 0f) return true; //block right
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

    #region Pick up box, Throw box, Destroy box

    void DestroyBox()
    {
        Destroy(m_bcCurBox);
        m_bcCurBox = null;
    }

    void DoBeforePickUpBox()
    {
        m_bcCurBox.gameObject.layer = HoldBoxMaskGlossy;
        m_bcCurBox.isTrigger = true;                                                                                            //将盒子变成触发器           
        m_fPlayerBoxRaidus = m_bcCurBox.size.y + Owner.ActorHeight * 0.5f ;                             //确认运动半径
        m_bcCurBox.transform.parent = Owner.ActorTrans.transform;                                          //将盒子变成主角的孩子
        m_bIsHoldBox = true;                                                                                                       //标识当前是举着箱子的状态
        StartCoroutine(PickUpBoxBehaviour());                                                                             //播放举箱子动画
    }

    IEnumerator PickUpBoxBehaviour()
    {
        //盒子繞著指定的半徑，圍繞主角做圓周運動

        while (m_bcCurBox.transform.localPosition.y < m_fPlayerBoxRaidus - 0.1f)
        {
            m_bcCurBox.transform.localPosition = Vector3.Lerp(m_bcCurBox.transform.localPosition, new Vector3(0f, m_fPlayerBoxRaidus, 0f), 30 * Time.deltaTime);

             yield return null;
        }

        m_bcCurBox.gameObject.transform.localRotation = Quaternion.identity;

    }


    #endregion

    #region 通用接口

    void ResetAllData()
    {
        m_bIsBlocked = false;
        m_bCollisionEntered = false;
        //m_vInputMove = Vector2.zero;
    }
    #endregion

}
