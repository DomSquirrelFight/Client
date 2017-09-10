using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

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

    //float m_fCurSpeed = 0f;                                                                                                      //获取当前的速度

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

        Owner = owner;
        cc = Owner.CameraContrl;
        m_curJumpData = Owner.SmallJumpDataStore;
    }

    public void PlayerMove()
    {

        //执行旋转操作
        RotatePlayer();
        //播放位移动画
        PlayMoveAnim();
        if (!CheckMoveBoundaryBlock())//判定横向是否超出朝向边界
        {
            if (!RayCastBlock(cc.CamMoveDir))//横向阻挡
            {
                //执行move操作
                TranslatePlayer();
            }
        }

        //执行小跳跃
        JumpBehaviour();

        //执行下跳操作
        JumpDownBehaviour();

        //switch (m_ePlayerBeha)
        //{
        //    case ePlayerBehaviour.eBehav_Normal:
        //        {
                  
        //            break;
        //        }
        //    case ePlayerBehaviour.eBehav_Hide:
        //        {
        //            break;
        //        }
        //    case ePlayerBehaviour.eBehav_JumpDown:
        //        {
        //            break;
        //        }
        //}
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

    public bool CalJumpDown()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Grounded && BCanJumpDown == true)
            {
#if UNITY_EDITOR
                Debug.Log("Can jump down");
#endif
                DoBeforeJump(ePlayerNormalBeha.eNormalBehav_JumpDown, 0f, true);
                return true;
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("Cann't jump down");
#endif
            }

        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos, GlobalHelper.SBoxSize * 0.5f);
        //Debug.DrawLine(pos, hitInfo.point);
    }
    RaycastHit m_HitInfo;
    Vector3 pos;
    public bool CalPickUpBox()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            //if (m_bIsHoldBox == false && m_bcCurBox != null && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide)
             if (m_bIsHoldBox == false && m_ePlayerNormalBehav < ePlayerNormalBeha.eNormalBehav_Hide && m_vInputMove.x != 0f)
            {

                float y = Owner.ActorTrans.position.y +Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;

                //if (y <= GlobalHelper.SBoxSize) // y < 0.8 -> y = 0.4
                //{
                //    y = GlobalHelper.SBoxSize * 0.5f;
                //   // y = 0f;
                //}
                //else if (y > GlobalHelper.SBoxSize && y <= 2 * GlobalHelper.SBoxSize)   //y >0.8f && y <= 1.6f -> y = 1.2
                //{
                //    y = GlobalHelper.SBoxSize * 0.5f + GlobalHelper.SBoxSize;
                //   // y = GlobalHelper.SBoxSize;
                //}
                //else                                                                                                       // y > 1.6f -> y = 2f;
                //{
                //    y = GlobalHelper.SBoxSize * 0.5f + GlobalHelper.SBoxSize * 2;
                //    //y = GlobalHelper.SBoxSize * 2;
                //}

                pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);
                //Debug.Log(Owner.ActorTrans.position + "  " + pos);
                 //if(Physics.Raycast(pos, Owner.ActorTrans.forward, out hitInfo, 1.5f, BoxMask)) {
                 //    Debug.DrawLine(pos, hitInfo.point);
                 //}

                //发射一个盒子
                 //SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
                if (Physics.SphereCast(pos, GlobalHelper.SBoxSize * 0.5f, Owner.ActorTrans.forward, out hitInfo, 1.5f, BoxMask))
                //if (Physics.BoxCast(pos, Vector3.one * 0.8f, Owner.ActorTrans.forward, out hitInfo, Quaternion.LookRotation(Owner.ActorTrans.forward), 1.5f, BoxMask))
                {
                    m_bcCurBox = (BoxCollider)hitInfo.collider;
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

        if ((other.contacts[0].otherCollider.gameObject.layer == BoxMaskGlossy || other.contacts[0].otherCollider.gameObject.layer == WallMaskGlossy) && m_vInputMove.x != 0f)
        {
            //需要发射朝向球体
            float y = Owner.ActorTrans.position.y + Owner.ActorHeight * 0.5f;//ActorHeight = 0.6f;

            pos = new Vector3(Owner.ActorTrans.position.x, y, Owner.ActorTrans.position.z);

            if (Physics.SphereCast(pos, GlobalHelper.SBoxSize * 0.5f, Owner.ActorTrans.forward, out hitInfo, 1.5f, 1 << other.contacts[0].otherCollider.gameObject.layer))     //如果在角色垂直向下方向射到了box，那么处理落地逻辑
            {
                if (hitInfo.collider.gameObject == other.collider.gameObject)
                {
                    m_bIsBlocked = true;
                }
            }
         
        }
        else
            m_bIsBlocked = false;


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
                //SetJumpDownState(other);
            }

        }
    }

    #endregion

    #region Jump

    void JumpDownBehaviour()                                                                                      //处理角色下跳行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_JumpDown)
        {
            //if (fOrigHeight - m_curHeight >= Owner.BC.size.y && m_bIsDescent == true)
            //todo_erric
            if (fOrigHeight - m_curHeight >= 1f && m_bIsDescent == true)
            {
                //Owner.RB.isKinematic = false;
                Owner.RB.velocity = Vector3.zero;
                m_bIsDescent = true;
                return;
            }

            CalCharacterJump();
        }
    }

    public void JumpBehaviour()                                                                                     //处理角色跳跃行为
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            if (Owner.RB.velocity.y <= 0f && m_bIsDescent == false)
            {
                m_bIsDescent = true;
                Owner.RB.velocity = new Vector3(0f, -1f, 0f);//将物体速度归0。
                Debug.Log("Jump to the top already");
                return;
            }
            //如果在下降，则直接返回
            if (m_bIsDescent)
                return;

           CalCharacterJump();

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

    void DoBeforeJump(ePlayerNormalBeha type, float InitSpeed, bool isDescent)                   //jump前的数据准备
    {

        //Owner.RB.isKinematic = true;
        Owner.RB.velocity = new Vector3(0f, InitSpeed, 0f);
        m_ePlayerNormalBehav = type;
        fOrigHeight = m_curHeight = Owner.ActorTrans.transform.position.y;
        //m_bIsDescent = false;
        m_bIsDescent = isDescent;
        m_fInitSpeed  = InitSpeed;
        m_fStartTime = Time.time;
    }

    void CalCharacterJump()                                                                         //计算角色位移<运动学刚体>
    {
        Owner.ActorTrans.transform.position = new Vector3(
               Owner.ActorTrans.transform.position.x,
               m_curHeight,
               Owner.ActorTrans.transform.position.z
               );
        m_fDuration = Time.time - m_fStartTime;
        
        Owner.RB.velocity = new Vector3(0f, m_fInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration), 0f);
        m_curHeight = fOrigHeight + (m_fInitSpeed * m_fDuration + 0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);
    }
   
    #endregion

    #region Translate
    bool RayCastBlock(eCamMoveDir side)
    {
        if (m_bIsBlocked)
            return true;
        return false;

    }

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
               Owner.ActorTrans.Translate(new Vector3(0f, 0f, GlobalHelper.SMoveSpeed * Time.deltaTime));
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