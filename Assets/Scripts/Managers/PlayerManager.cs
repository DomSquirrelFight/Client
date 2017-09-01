using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class PlayerManager : MonoBehaviour
{

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

    #region 变量
    ePlayerBehaviour m_ePlayerBeha = ePlayerBehaviour.eBehav_Normal;//角色行为
    ePlayerNormalBeha m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Null;
    bool m_bGounded = false;
    BaseActor Owner;
    CameraController cc;
    int mask;
    JumpDataStore m_curJumpData;
    #endregion

    #region 启动接口
    public void OnStart(BaseActor owner)
    {
        mask = 1 << LayerMask.NameToLayer("Ground");
        Owner = owner;
        cc = Owner.CameraContrl;
        m_curJumpData = Owner.SmallJumpDataStore;
    }
    #endregion

    #region 检测输入
    Vector2 m_vInputMove;
    public void CalMoveInput()//发送平移输入
    {
        m_vInputMove.x = Input.GetAxis("Horizontal");
        m_vInputMove.y = Input.GetAxis("Vertical");
        m_ePlayerBeha = ePlayerBehaviour.eBehav_Normal;
    }
    #endregion

    #region 处理角色运动

    Ray ray1, ray2, ray3;
    Vector3 pos, pos1;
    bool HitGround()
    {
        TmpDis = Owner.ActorHeight + 1f;
        ray1 = new Ray(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, Vector3.down);//从自身的中心点开始向下发射.

        pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight - Vector3.right * Owner.ActorSize;
        if (Owner.ActorTrans.transform.forward.x < 0)
            pos = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Vector3.right * Owner.ActorSize;

        pos1 = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight + Vector3.right * Owner.ActorSize;
        if (Owner.ActorTrans.transform.forward.x < 0)
            pos1 = Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight - Vector3.right * Owner.ActorSize;

        ray2 = new Ray(pos, Vector3.down);//从自身的中心点尾部开始向下发射.
        ray3 = new Ray(pos1, Vector3.down);//从自身的中心点头部开始向下发射.
        if (Physics.Raycast(ray1, out hitInfo, TmpDis, mask) || Physics.Raycast(ray2, out hitInfo, TmpDis, mask) || Physics.Raycast(ray3, out hitInfo, TmpDis, mask))
        {
            TmpDis = Owner.ActorTrans.transform.position.y + Owner.ActorHeight - hitInfo.point.y;
            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorHeight, hitInfo.point, Color.green);

            //if (m_ePlayerNormalBehav > ePlayerNormalBeha.eNormalBehav_Null && m_bIsDescent)
            //{
            //    int a = 0;
            //}


            if (TmpDis < Owner.ActorHeight + 0.1f && TmpDis > 0f)
            {
                if (
                    (m_ePlayerNormalBehav > ePlayerNormalBeha.eNormalBehav_Null && m_bIsDescent) ||
                    m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Null
                    )
                {
                    m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_Null;
                    m_bGounded = true;
                    m_bIsDescent = false;
                    Owner.ActorTrans.position = new Vector3(
                        Owner.ActorTrans.position.x,
                        hitInfo.point.y,
                        Owner.ActorTrans.position.z
                        );
                    return true;
                }
            }
        }
        //double dis = (double)distance;
        //dis = System.Math.Round(dis, 2);

        m_bGounded = false;
        return false;
    }

    void FixedUpdate()
    {
        HitGround();//检测是否落地
    }

    //横向运动，遇到障碍物，进行阻挡
    float TmpDis;
    RaycastHit hitInfo;
    bool RayCastBlock(eCamMoveDir side)
    {

        TmpDis = Owner.ActorSize + 0.2f;
        if (Physics.Raycast(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorSize, m_vInputMove.x * Vector3.right, out hitInfo, TmpDis, mask))
        {
            //绘制射线
#if UNITY_EDITOR
            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * Owner.ActorSize, hitInfo.point, Color.blue);
#endif

            if (m_vInputMove.x < 0f)//朝左运动
            {
                if ((Owner.ActorTrans.transform.position.x - hitInfo.point.x) > 0f && (Owner.ActorTrans.transform.position.x - hitInfo.point.x) < Owner.ActorSize + 0.1f)
                    return true;
            }
            else if (m_vInputMove.x > 0f)//朝右运动
            {
                if ((hitInfo.point.x - Owner.ActorTrans.transform.position.x) > 0f && (hitInfo.point.x - Owner.ActorTrans.transform.position.x) < Owner.ActorSize + 0.1f)
                    return true;
            }
        }

        return false;
    }

    public void PlayerMove()
    {
        switch (m_ePlayerBeha) {
            case ePlayerBehaviour.eBehav_Normal:
                {
                    NormalMove();
                    break;
                }
            case ePlayerBehaviour.eBehav_Hide:
                {
                    break;
                }
            case ePlayerBehaviour.eBehav_JumpDown:
                {
                    break;
                }
        }
    }

    #region Player_NormalBehaviour
    void NormalMove()
    {
        //执行旋转操作
        RotatePlayer();
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

    }

    #region Player Translate
    Vector3 m_vCurForward;
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
        if(m_vInputMove.x == 0f)
            Owner.AM.SetFloat(NameToHashScript.SpeedId, 0f);
        else
        {
            Owner.AM.SetFloat(NameToHashScript.SpeedId, 1f);
            Owner.ActorTrans.Translate(new Vector3(0f, 0f, GlobalHelper.SMoveSpeed * Time.deltaTime));
        }

        #region 如果未落地 && 不是跳跃模式 -> 开始自由下落模式
        if (!m_bGounded && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Null)
        {
             //开始自由下落

            //记录当前高度
            m_curHeight = Owner.ActorTrans.transform.position.y;

            //记录当前速度
            
            /*
             * 
             * 
             * 
             * */

        }
        #endregion
        
    }

    /// <summary>
    /// 判定是否超出朝向边界
    /// </summary>
    /// <returns>如果游戏必须向右行进，那么当角色运行到相机视野的左边界的时候，那么就不能再继续行走了</returns>
    bool CheckMoveBoundaryBlock() {

        if (m_vInputMove.x == 0f)
            return false;

        if (cc.CamMoveDir == eCamMoveDir.CamMove_Right)
        {
            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.LeftPoint.x + Owner.ActorSize && m_vInputMove.x < 0f) return true;//block left
        }
        else if(cc.CamMoveDir == eCamMoveDir.CamMove_Left)
        {
            if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.RightPoint.x - Owner.ActorSize && m_vInputMove.x > 0f) return true; //block right
        }
    
        return false; 
    }
    #endregion

    #region Player Jump
    public bool CalJumpInput()
    {
        if (m_bGounded == true && m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_Null)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K))
            {
               
                DoBeforeJump();
                return true;
            }
              
        }
        return false;
    }
    //readonly float fSmallJumpHeight = 1.875f;//跳跃高度
    //readonly float fSmallJumpInitSpeed = 7.5f;//初始速度
    //readonly float fSmallJumpAccel = -15f;//加速度
    float fOrigHeight = 0f;
    float m_curHeight = 0f;
    bool m_bIsDescent = false;
    float m_fCurSpeed = 0f;
    float m_fStartTime = 0f;
    float m_fDuration = 0;
    void DoBeforeJump()
    {
        m_ePlayerNormalBehav = ePlayerNormalBeha.eNormalBehav_SmallJump;
        fOrigHeight = m_curHeight = Owner.ActorTrans.transform.position.y;
        m_bIsDescent = false;
        m_fCurSpeed = m_curJumpData.m_fJumpInitSpeed;
        m_fStartTime = Time.time;
    }

    public void JumpBehaviour()
    {
        if (m_ePlayerNormalBehav == ePlayerNormalBeha.eNormalBehav_SmallJump)
        {
            //m_curHeight >= fOrigHeight + fSmallJumpHeight
            if (m_fCurSpeed <=0f && m_bIsDescent == false)
            {
                m_bIsDescent = true;
            }

            Owner.ActorTrans.transform.position = new Vector3(
                Owner.ActorTrans.transform.position.x,
                m_curHeight,
                Owner.ActorTrans.transform.position.z
                );
            m_fDuration = Time.time - m_fStartTime;

            m_fCurSpeed = m_curJumpData.m_fJumpInitSpeed + (m_curJumpData.m_fJumpAccel * m_fDuration);
            //m_curHeight += m_fCurSpeed * Time.deltaTime * 10;
            m_curHeight = fOrigHeight + (m_curJumpData.m_fJumpInitSpeed * m_fDuration + 0.5f * m_curJumpData.m_fJumpAccel * m_fDuration * m_fDuration);
            //Debug.Log(m_fCurSpeed + " " +  m_curHeight + "   " + m_fDuration);
            //m_fCurSpeed = fSmallJumpInitSpeed + fSmallJumpAccel * m_fDuration;
            //m_curHeight += m_fCurSpeed * Time.deltaTime ;

        }
    }
    #endregion

    #endregion

    #endregion



}
