﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System.Linq;
public class PlayerManager : MonoBehaviour
{

    #region 变量
    //ePlayerBehaviour m_ePlayerBeha = ePlayerBehaviour.eBehav_Normal;                                                                        //角色行为
    
    ePlayerNormalBeha m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;                                             //角色普通行为
    
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

    float PI = 3.1415926f;

    

    #endregion

    #region 外部接口
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
        cc = Owner.CameraContrl;
        m_curJumpData = Owner.SmallJumpDataStore;

        //k1 = (m_curJumpData.m_fJumpHeight - 0.1f) / Owner.ActorHeight;
        //k2 = (m_curJumpData.m_fJumpHeight - 0.1f - GlobalHelper.SBoxSize * 2) / Owner.ActorHeight;

        //角色垂直上跳，碰到brick的距离
        m_fUpDisForBrick = m_curJumpData.m_fJumpHeight - 0.2f - Owner.ActorHeight + 0.1f;

        float tmp = m_curJumpData.m_fJumpHeight + 0.1f;
        float dis = Mathf.Sqrt(tmp * tmp * 2);
        //float halfDiagonal = Mathf.Sqrt(Owner.ActorHeight * Owner.ActorHeight * 2) * 0.5f;
        m_fBiasDisForBrick = dis;// -halfDiagonal + 0.1f;

    }

    public void PlayerMove()
    {
        //执行旋转操作
        RotatePlayer();
        //播放位移动画
        PlayMoveAnim();
        if (!CheckMoveBoundaryBlock())//判定横向是否超出朝向边界
        {
           // if (!RayCastBlock(cc.CamMoveDir))//横向阻挡
            {
                //执行move操作
                TranslatePlayer();
            }
            m_bIsBlocked = false;

        }

        //角色自由下落
        //FreeFall();

        //执行小跳跃
        JumpBehaviour();

        //执行下跳操作
        //JumpDownBehaviour();

    }
    #endregion

    #region 检测输入
    Vector2 m_vInputMove;                                                   //发送平移输入
    
    public void CalMoveInput()                                              //获取平移输入
    {
        m_vInputMove.x = Input.GetAxis("Horizontal");
        m_vInputMove.y = Input.GetAxis("Vertical");
        //m_ePlayerBeha = ePlayerBehaviour.eBehav_Normal;

#if UNITY_EDITOR
        if (0f != m_vInputMove.x)
        {
            int a = 0;
        }
#endif
    }

    public bool IsJump()
    {
        if (m_ePlayerNormalBehav > ePlayerNormalBeha.eNormalBehav_Grounded)
            return true;
        return false;
    }

    public bool CalJumpInput()                                              //获取跳跃输入
    {
        if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded)
        //if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K))
            {
                DoBeforeJump(ePlayerNormalBeha.eNormalBehav_SmallJump, m_curJumpData.m_fJumpInitSpeed, false);
                return true;
            }

        }
        return false;
    }

    //bool CheckJumpDown()                                                 //解决在下跳的时候，下一层有很多的盒子，导致角色不能完全跳下去，而卡在两个层中间
    //{

    //    float y = Owner.ActorTrans.position.y;
    //    pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);
    //    if (Physics.SphereCast(pos, 0.3f, (new Vector3((m_vInputMove.x) * GlobalHelper.SMoveSpeed, 0 - (Mathf.Abs(m_vInputMove.x) * GlobalHelper.SMoveSpeed * k2), 0f)).normalized, out hitInfo, Owner.ActorHeight * 2.5f + 0.1f, BoxMask))
    //    {
    //        return false;
    //    }
    //    else if (Physics.SphereCast(pos, 0.3f, (new Vector3((m_vInputMove.x) * GlobalHelper.SMoveSpeed, 0 - (Mathf.Abs(m_vInputMove.x) * GlobalHelper.SMoveSpeed * k1), 0f)).normalized, out hitInfo, Owner.ActorHeight * 2.5f + 0.1f, BoxMask))
    //    {
    //        return false;
    //    }
    //    else if (Physics.SphereCast(pos, 0.3f, Vector3.down, out hitInfo, Owner.ActorHeight * 2.5f + 0.1f, BoxMask))
    //    {
    //        return false;
    //    }

    //    return true;
    //}
//    public bool CalJumpDown()
//    {
//        if (Input.GetKeyDown(KeyCode.J))
//        {
//            if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && BCanJumpDown == true)
//            {
//#if UNITY_EDITOR
//                Debug.Log("Can jump down");
//#endif
//                if (!CheckJumpDown())                   //检查下落的下方是否有盒子.
//                {
//                    BCanJumpDown = false;
//                    return false;
//                }

//                Owner.RB.isKinematic = true;
//                DoBeforeJump(ePlayerNormalBeha.eNormalBehav_JumpDown, 0f, true);
//                return true;
//            }
//            else
//            {
//#if UNITY_EDITOR
//                Debug.Log("Can't jump down");
//#endif
//            }
//        }
//        return false;
//    }

    RaycastHit m_HitInfo;
    Vector3 pos;


    public bool CalPickUpBox()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            //if (m_bIsHoldBox == false && m_bcCurBox != null && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide)
            if (m_bIsHoldBox == false && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide && m_vInputMove.x != 0f && null == m_bcCurBox)
            {

                float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;
                pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

                //拿到所有的盒子，然后判定盒子位置最低的
                RaycastHit[] hits = Physics.BoxCastAll(pos, new Vector3 (0.1f, Owner.ActorHeight * 0.5f, Owner.ActorHeight * 0.5f), Owner.ActorTrans.forward, Quaternion.Euler (Owner.ActorTrans.forward), Owner.ActorHeight * 0.5f + 0.2f, BoxMask);
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
        }
        return false;
    }

    #endregion

    #region 检测碰撞

    void OnCollisionStay(Collision other)
 //   void OnCollisionEnter(Collision other)
    {

        //if ((other.contacts[0].otherCollider.gameObject.layer == BoxMaskGlossy || other.contacts[0].otherCollider.gameObject.layer == WallMaskGlossy) && m_vInputMove.x != 0f)
        //{
        //    //需要发射朝向球体
        //    float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;

        //    pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

        ////    //if (Physics.SphereCast(pos, GlobalHelper.SBoxSize * 0.5f, Owner.ActorTrans.forward, out hitInfo, 1.5f, 1 << other.contacts[0].otherCollider.gameObject.layer))     //如果在角色运动正方向发现box，那么判定为阻挡状态
        //    //{
        //    //    if (hitInfo.collider.gameObject == other.collider.gameObject)
        //    //    {
        //    //        m_bIsBlocked = true;
        //    //    }
        //    //}
         
        //}
        //else
        //    m_bIsBlocked = false;


        if (other.contacts.Length > 0)
        {
            if (other.contacts[0].thisCollider.gameObject.layer == NpcMaskGlossy)                                    //角色碰到了ground, brick or box
            {

                //OperateGround(other, mask);

                if (other.contacts[0].otherCollider.gameObject.layer == BoxMaskGlossy)                              //如果判定碰到的是box
                {
                    OperateGround(other, BoxMask);
                }
                else if (other.contacts[0].otherCollider.gameObject.layer == BrickMaskGlossy)                                           //如果判定接触到的是brick
                {
                    OperateGround(other, BrickMask);
                }
                else if (other.contacts[0].otherCollider.gameObject.layer == MaskGlossy)
                {
                    //OperateGround(other, mask);
                    if (m_bIsDescent)
                    {
                        SetJumpDownState(other);
                    }
                }
            }
        }
    }

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

    //void FreeFall()
    //{
    //    if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && m_bIsDescent == false && Owner.RB.velocity.y < 0f)
    //    {
    //        DoBeforeJump(ePlayerNormalBeha.eNormalBehav_JumpDown, Owner.RB.velocity.y, true);
    //    }
    //}

    //void JumpDownBehaviour()                                                                                      //处理角色下跳行为
    //{
    //    if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)
    //    {
    //        //if (fOrigHeight - m_curHeight >= Owner.BC.size.y && m_bIsDescent == true)
    //        //todo_erric
    //        if (fOrigHeight - m_curHeight >= Owner.ActorHeight && m_bIsDescent == true)
    //        {
    //            Owner.RB.isKinematic = false;
    //            Owner.RB.velocity = new Vector3(0f, m_fCurSpeed, 0f);
    //            m_bIsDescent = true;
    //            return;
    //        }
    //        CalCharacterJump();
    //    }
    //}

    public void JumpBehaviour()                                                                                     //处理角色跳跃行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            if (m_fCurSpeed <= 0f && m_bIsDescent == false)
            {
                m_bIsDescent = true;
                Owner.RB.isKinematic = false;
                Owner.RB.velocity = new Vector3(0f, -1f, 0f);//将物体速度归0。
                //Debug.Log("Jump to the top already");
                return;
            }
            //如果在下降，则直接返回
            if (m_bIsDescent)
                return;
            else
            {

                SetPlayerKinematic(); //设置玩家是否可以穿越障碍.
                CalCharacterJump();
            }

        }

    }

    void SetJumpDownState(Collision other)                                                                      //设置角色下跳权限
    {
        m_bGounded = true;
        m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;
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
        ExtDebug.DrawBoxCastBox(
        Owner.ActorTrans.position + Vector3.up * 0.44f,
        new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
        Quaternion.identity, new Vector3(0f, 1f, 0f), m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f, Color.green
        );

        if (Physics.BoxCast(Owner.ActorTrans.position + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up, out m_rayCheckJumpBrick, Quaternion.Euler(Vector3.up),
            m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f, BoxMask))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(m_rayCheckJumpBrick.point, 0.1f * Vector3.one);
        }

        Debug.DrawLine(Owner.ActorTrans.position + Vector3.up * 0.44f, 
                                   Owner.ActorTrans.position + Vector3.up * 0.44f + Vector3.up * (m_curJumpData.m_fJumpHeight + GlobalHelper.SBoxSize + 0.1f), Color.green);



        ExtDebug.DrawBoxCastBox(
        Owner.ActorTrans.position - Owner.BC.size.x * 0.5f * Vector3.right * tmpx + Vector3.up * 0.44f,
        new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
        Quaternion.LookRotation((new Vector3(tmpx * -1f, 1f, 0f)).normalized), new Vector3(tmpx * 1f, 1f, 0f), m_fBiasDisForBrick * 2f, Color.red
        );

        Gizmos.color = Color.red;
        RaycastHit[] hits = Physics.BoxCastAll(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f),
                                                                                    Vector3.up + Vector3.right * tmpx, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick * 2f, BoxMask);

        for (int i = 0; i < hits.Length; i++)
        {
            Gizmos.DrawSphere(hits[i].point, 0.1f);
        }

            //if (Physics.BoxCast(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up + Vector3.right * tmpx, out m_rayCheckJumpBrick, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick * 2f, BoxMask))
            //{
               
                
            //}

        Debug.DrawLine(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f,
            Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f + (Vector3.up + Vector3.right * tmpx) * (2*m_fBiasDisForBrick),
            Color.red);

        lastTmpx = tmpx;

    }



    void DoBeforeJump(ePlayerNormalBeha type, float InitSpeed, bool isDescent)                   //jump前的数据准备
    {
        //float t = 0.04f;
        //float a = 12f * t - 20f * t * t;

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
    void SetPlayerKinematic()
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
                        tmpx = 1f;
                        if (Owner.ActorTrans.forward.x < 0f)
                            tmpx = -1;
                        //if (Physics.BoxCast(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f + Vector3.up * 0.44f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), Vector3.up + Vector3.right * tmpx, out m_rayCheckJumpBrick, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick, BoxMask))
                            
                            //检测全部的box，
                            /*
                             * if(length <= 0) {iskinematic = true}
                             * else {
                             *          
                             * }
                             * 
                             * */
                            RaycastHit[] hits = Physics.BoxCastAll(Owner.ActorTrans.position - tmpx * Vector3.right * Owner.ActorHeight * 0.5f, new Vector3(Owner.ActorHeight * 0.5f, 0.1f, Owner.ActorHeight * 0.5f), 
                                                                                      Vector3.up+Vector3.right * tmpx, Quaternion.LookRotation((new Vector3(tmpx * -1, 1, 0)).normalized), m_fBiasDisForBrick * 2f, BoxMask);
                            
                            if(hits.Length <= 0)
                                Owner.RB.isKinematic = true;
                            else
                            {
                                /*
                         * dis = 0.5 - 0.44 + 0.2f; -> 0.26f
                         * v0 * t + 0.5f * a * t * t = 0.26f
                         * 
                         * a = 0.5f * a;
                         * b = v0
                         * c = -0.26;
                         * 
                         * */
                                float v0 = m_curJumpData.m_fJumpInitSpeed + 0.5f * m_curJumpData.m_fJumpAccel * fCheckJumpTime;
                                float a = 0.5f * m_curJumpData.m_fJumpAccel;
                                float b = v0;
                                float c = 0f - 0.26f;

                                float upright = Mathf.Sqrt(b * b - 4f * a * c);
                                float upleft = 0 - b;
                                float down = 2f * a;


                                float t1 = (upleft - upright) / down;
                                float t2 = (upleft + upright) / down;

                                float t = t1 < t2 ? t1 : t2;
                                if (t < 0f)
                                {
                                    Debug.LogErrorFormat("t1 = {0}, t2 = {1}", t1, t2);
                                    return;
                                }

                                //bool test = false;

                                float s = GlobalHelper.SMoveSpeed * t;
                                int i = 0;
                                for (i = 0; i < hits.Length; i++)
                                {
                                    float s1 = Mathf.Abs(hits[i].transform.position.x - Owner.ActorTrans.position.x) - Owner.ActorHeight * 0.5f - GlobalHelper.SBoxSize * 0.5f;
                                    if (s1 <= s + 0.2f)
                                    {
                                        //Owner.RB.isKinematic = true;
                                        //test = true;
                                        break;
                                    }
                                }
                                //if (test)
                                //    Debug.Log(i + "hits.length = " + hits.Length);
                                //else
                                //{

                                //    Debug.Log("cur index = " + i + "hits.length = " + hits.Length);
                                //}
                                if(i == hits.Length) {
                                    Owner.RB.isKinematic = true;
                                }

                            }  
                    }
            }
        }
    }

    void CalCharacterJump()                                                                         //计算角色位移<运动学刚体>
    {
        Owner.ActorTrans.transform.position = new Vector3(
               Owner.ActorTrans.transform.position.x,
               m_curHeight,
               Owner.ActorTrans.transform.position.z
               );
        m_fDuration = Time.time - m_fStartTime;
        if(Owner.RB.isKinematic == false) {
              Owner.RB.velocity = new Vector3(0f, m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration), 0f);
              m_fCurSpeed = Owner.RB.velocity.y;
        }
        else {
            m_fCurSpeed = m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration);
        }
        
      
        m_curHeight = fOrigHeight + (m_fInitSpeed * m_fDuration + 0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);
    }
   
    #endregion

    #region Translate
    //bool RayCastBlock(eCamMoveDir side)
    //{
    //    if (m_bIsBlocked)
    //        return true;
    //    else
    //    {
    //        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)    //添加jump down 逻辑
    //        {
    //            float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;
    //            pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);
    //            if (Physics.SphereCast(pos, 0.2f, Owner.ActorTrans.forward, out hitInfo, 1.5f))
    //                m_bIsBlocked = true;
    //        }
    //    }
    //    return m_bIsBlocked;

    //}

    void RotatePlayer()
    {
        if (m_vInputMove.x != 0f)
        {
            m_vCurForward = new Vector3(m_vInputMove.x, 0f, 0f);
            Owner.ActorTrans.forward = Vector3.Lerp(Owner.ActorTrans.forward, m_vCurForward, GlobalHelper.SRotSpeed * Time.deltaTime);
            //Debug.Log(Owner.ActorTrans.forward);
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



}

//    #region 通用变量和接口
//    ePlayerState m_ePlayerState = ePlayerState.PlayerState_Idle;//角色状态
//    BaseActor Owner;
//    CameraController cc;
//    int mask;
//    float dist;
//    //返回的碰撞信息
//    RaycastHit hitInfo;
//    public void OnStart(BaseActor owner)
//    {
//        mask = 1 << LayerMask.NameToLayer("Ground");
//        Owner = owner;
//        cc = Owner.CameraContrl;
//        dist = 10f;
//    }
//    void Update()
//    {

//        if (!Owner) return;

//        HitGround();//判定是否落地

//        m_fHorizontal = Input.GetAxis("Horizontal");//获取Z轴方向移动指令
//        //m_fVertical = Input.GetAxis("Vertical");//获取Y轴方向移动指令
//        switch (cc.CamMoveDir)
//        {
//            case eCamMoveDir.CamMove_Left:
//            case eCamMoveDir.CamMove_Right:
//                {
//                    if (0f == m_fHorizontal)
//                    {
//                        Owner.AM.SetFloat(NameToHashScript.SpeedId, 0f);
//                    }
//                    else
//                    {
//                        PlayerMove();//角色移动
//                    }

//                    //判定当前是否可以跳跃 <当前的状态>
//                    if (CanJump())
//                    {
//                        if (IsTriggerJump())//触发跳跃
//                        {
//                            DoBeforeJump();//准备跳跃
//                        }
//                    }
//                    JumpBehaviour();//跳跃
//                    break;
//                }
//            case eCamMoveDir.CamMove_Up:
//            case eCamMoveDir.CamMove_Down:
//                {
//                    //Block Left and Block right

//                    //不处理相机中点
//                    break;
//                }
//        }
//    }
//    #endregion

//    #region 角色move
//    float m_fHorizontal = 0f;
//    float m_fVertical = 0f;
//    Vector3 m_vCurForward = Vector3.zero;
//    Vector3 dir;
//    float TmpDis;
//    //横向运动，遇到障碍物，进行阻挡
//    bool RayCastBlock(eCamMoveDir side)
//    {

//        TmpDis = Owner.ActorSize + 0.2f;
//        if (Physics.Raycast(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorSize, m_fHorizontal * Vector3.right, out hitInfo, TmpDis, mask))
//        {
//            //绘制射线
//#if UNITY_EDITOR
//            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorSize, hitInfo.point, Color.blue);
//#endif

//            if (m_fHorizontal < 0f)//朝左运动
//            {
//                if ((Owner.ActorTrans.transform.position.x - hitInfo.point.x) > 0f && (Owner.ActorTrans.transform.position.x - hitInfo.point.x) < Owner.ActorSize + 0.1f)
//                    return true;
//            }
//            else if (m_fHorizontal > 0f)//朝右运动
//            {
//                if ((hitInfo.point.x - Owner.ActorTrans.transform.position.x) > 0f && (hitInfo.point.x - Owner.ActorTrans.transform.position.x) < Owner.ActorSize + 0.1f)
//                    return true;
//            }
//        }

//        return false;
//    }

//    void PlayerMove()
//    {
//        Owner.AM.SetFloat(NameToHashScript.SpeedId, 1f);
//        m_vCurForward = new Vector3(m_fHorizontal, 0f, 0f);
//        Owner.ActorTrans.forward = Vector3.Lerp(Owner.ActorTrans.forward, m_vCurForward, 60 * Time.deltaTime);

//        //视野范围判断，超出范围进行阻挡
//        if (cc.CamMoveDir == eCamMoveDir.CamMove_Right)
//        {
//            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.LeftPoint.x + Owner.ActorSize && m_fHorizontal < 0f) return;//block left
//        }
//        else
//        {
//            if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.RightPoint.x - Owner.ActorSize && m_fHorizontal > 0f) return; //block right
//        }

//        if (RayCastBlock(cc.CamMoveDir))//是否遇到阻挡
//            return;

//        Owner.ActorTrans.Translate(new Vector3(0f, 0f, 3 * Time.deltaTime));
//    }

//    #endregion

//    #region jump

//    bool CanJump()//判定是否可以跳跃
//    {
//        if (m_ePlayerState < ePlayerState.PlayerState_SmallJump && m_fIsGrounded)
//            return true;

//        return false;
//    }

//    bool IsTriggerJump()
//    {
//        if (Input.GetKeyDown(KeyCode.K))
//            return true;
//        return false;
//    }

//    float JumpHeight = 3f;
//    float JumpAcceleration = 10f;
//    float OrigHeight = 0f;
//    float CurHeight = 0f;
//    bool m_fIsGrounded = false;
//    float CurAcceleration = 0f;
//    void DoBeforeJump()
//    {
//        m_ePlayerState = ePlayerState.PlayerState_SmallJump;//设置当前状态
//        OrigHeight = Owner.ActorTrans.position.y;
//        CurHeight = OrigHeight;
//        CurAcceleration = JumpAcceleration;
//        Owner.RB.isKinematic = true;
//    }


//    Ray ray1, ray2;
//    Vector3 pos;
//    bool HitGround()
//    {
//        TmpDis = Owner.ActorHeight + 1f;
//        ray1 = new Ray(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, Vector3.down);//从自身的中心点开始向下发射.

//        pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight - Vector3.right * Owner.ActorSize;
//        if(Owner.ActorTrans.transform.forward.x < 0)
//            pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Vector3.right * Owner.ActorSize;
//        ray2 = new Ray(pos, Vector3.down);//从自身的中心点开始向下发射.

//        if (Physics.Raycast(ray1, out hitInfo, TmpDis, mask) || Physics.Raycast(ray2, out hitInfo, TmpDis, mask))
//        {
//            TmpDis = Owner.ActorTrans.transform.position.y + Owner.ActorHeight - hitInfo.point.y;
//            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, hitInfo.point, Color.green);
//        }
//        //double dis = (double)distance;
//        //dis = System.Math.Round(dis, 2);

//        if (TmpDis < Owner.ActorHeight && TmpDis > 0f)
//        {
//            m_ePlayerState = ePlayerState.PlayerState_Idle;
//            Owner.RB.isKinematic = false;
//            m_fIsGrounded = true;
//            return true;
//        }
//        m_fIsGrounded = false;
//        return false;
//    }

//    void JumpBehaviour()
//    {
//        //如果当前是跳跃状态
//        if (m_ePlayerState >= ePlayerState.PlayerState_SmallJump)
//        {
//            if (CurHeight - OrigHeight >= JumpHeight)//判断是否跳到了最大高度
//            {
//                Owner.RB.isKinematic = false;
//            }
//            else
//            {
//                CurHeight += (CurAcceleration * Time.deltaTime);

//                Owner.ActorTrans.position = new Vector3(
//                      Owner.ActorTrans.position.x,
//                      CurHeight,
//                      Owner.ActorTrans.position.z
//                    );
//            }
//        }

//    }

//    #endregion

//    #region 捡起箱子
//    void PickUpBox()
//    {

//    }
//    #endregion
/// <summary>
/// 判定是否超出朝向边界
/// </summary>
/// <returns>如果游戏必须向右行进，那么当角色运行到相机视野的左边界的时候，那么就不能再继续行走了</returns>
/// 
//    #region 判定角色是否落地 HitGround
//    Ray ray1, ray2, ray3;
//    Vector3 pos, pos1;

////    bool HitGround()
////    {
////        //设定射线长度 <角色身高>
////        TmpDis = Owner.ActorHeight*2f;

////        //从自身的中心点开始向下发射.
////        ray1 = new Ray(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, Vector3.down);

////        pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight - Vector3.right * Owner.ActorSize;
////        if (Owner.ActorTrans.transform.forward.x < 0)
////            pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Vector3.right * Owner.ActorSize;

////        pos1 = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Vector3.right * Owner.ActorSize;
////        if (Owner.ActorTrans.transform.forward.x < 0)
////            pos1 = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight - Vector3.right * Owner.ActorSize;

////        //从自身的中心点尾部开始向下发射.
////        ray2 = new Ray(pos, Vector3.down);

////        //从自身的中心点头部开始向下发射.
////        ray3 = new Ray(pos1, Vector3.down);

////        //从角色发射三条向下的射线
////       // if (Physics.Raycast(ray1, out hitInfo, TmpDis, mask) || Physics.Raycast(ray2, out hitInfo, TmpDis, mask) || Physics.Raycast(ray3, out hitInfo, TmpDis, mask))
////        // public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask);
////        //public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask);
////        if (Physics.BoxCast(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Owner.BC.center, Owner.BC.size * 0.4f, Vector3.down, out hitInfo, Quaternion.Euler(Vector3.down), TmpDis, mask))
////       // if (Physics.BoxCast(new Vector3(0, 8, 0), Owner.BC.size*20, Vector3.down, out hitInfo, Quaternion.identity, TmpDis*30, mask))
////        {
////            //获取当前角色的位置和触发点的位置
////            TmpDis = Owner.ActorTrans.transform.position.y - hitInfo.point.y;

////#if UNITY_EDITOR
////            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, hitInfo.point, Color.green);

////            if (m_ePlayerNormalBehav > ePlayerNormalBeha.eNormalBehav_Grounded && m_bIsDescent)
////            {
////                int a = 0;
////            }
////#endif

////            if (TmpDis < Owner.ActorHeight  && TmpDis > (0 - Owner.ActorHeight))
////            {
////                if (
////                    (m_ePlayerNormalBehav > ePlayerNormalBeha.eNormalBehav_Grounded && m_bIsDescent) ||
////                    m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded
////                    )
////                {
////                    m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Grounded;
////                    m_bGounded = true;
////                    m_bIsDescent = false;
////                    Owner.ActorTrans.position = new Vector3(
////                        Owner.ActorTrans.position.x,
////                        hitInfo.point.y,
////                        Owner.ActorTrans.position.z

////                        );
////                    return true;
////                }
////            }
////        }

////        m_bGounded = false;

////        return false;

////    }

////    void FixedUpdate()
////    {
////        //HitGround();//检测是否落地
////    }
//    #endregion
    ////<Deprecated>
    //void DoBeforeFreeFall()
    //{
    //    m_fStartTime = Time.time;
    //    m_curHeight = fOrigHeight = Owner.ActorTrans.transform.position.y;
    //}
//#region 如果未落地 && 不是跳跃模式 -> 开始自由下落模式
//if (!m_bGounded && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded)
//{
//    Owner.ActorTrans.transform.position = new Vector3(
//     Owner.ActorTrans.transform.position.x,
//     m_curHeight,
//     Owner.ActorTrans.transform.position.z
//     );
//    m_fDuration = Time.time - m_fStartTime;
//    m_fCurSpeed = (m_curJumpData.m_fJumpAccel * m_fDuration);
//    m_curHeight = fOrigHeight + (0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);

//}
//#endregion
//#if UNITY_EDITOR
//    bool m_bIsRayCastTranslateBlocked = false;
//    void OnDrawGizmos()
//    {
//        if (m_bIsRayCastTranslateBlocked)
//        {
//            Gizmos.color = Color.blue;
//            Gizmos.DrawCube(Owner.ActorTrans.transform.position + Owner.BC.center, Owner.BC.size * 0.5f);
//        }
//    }
// #endif
//void OnDrawGizmos()
//{
//    //Gizmos.color = Color.red;
//    //Gizmos.DrawSphere(pos, GlobalHelper.SBoxSize * 0.5f);
//    //Debug.DrawLine(pos, hitInfo.point);

//        // !Physics.SphereCast(pos, 0.1f, , out hitInfo, Owner.ActorHeight * 4.4f, BoxMask))
//    //Gizmos.DrawRay(Owner.ActorTrans.position, (new Vector3(GlobalHelper.SMoveSpeed * (m_vInputMove.x), m_fCurSpeed, 0f)).normalized);
//    //Debug.Log((new Vector3(GlobalHelper.SMoveSpeed * (m_vInputMove.x) , m_fCurSpeed, 0f)).normalized);

//}