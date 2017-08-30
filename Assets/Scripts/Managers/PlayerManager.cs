using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class PlayerManager : MonoBehaviour
{

    #region 通用变量和接口
    ePlayerState m_ePlayerState = ePlayerState.PlayerState_Idle;//角色状态
    BaseActor Owner;
    CameraController cc;
    int mask;
    float dist;
    //返回的碰撞信息
    RaycastHit hitInfo;
    public void OnStart(BaseActor owner)
    {
        mask = 1 << LayerMask.NameToLayer("Ground");
        Owner = owner;
        cc = Owner.CameraContrl;
        dist = 10f;
    }
    void Update()
    {

        if (!Owner) return;

        if (HitGround())
            return;

        JumpBehaviour();//角色跳跃

        PlayerMove();//角色移动

    }
    #endregion

    #region 角色move
    float m_fHorizontal = 0f;
    float m_fVertical = 0f;
    Vector3 m_vCurForward = Vector3.zero;
    Vector3 dir;
    bool RayCastBlock(eCamMoveDir side)
    {

        dir = Vector3.right;
        if (side == eCamMoveDir.CamMove_Left)
            dir = Vector3.left;
        if (Physics.Raycast(Owner.ActorTrans.transform.position + Vector3.up * 0.1f, m_fHorizontal * dir, out hitInfo, dist, mask))
        {
            //绘制射线
            Debug.DrawLine(Owner.ActorTrans.transform.position + Vector3.up * 0.1f, hitInfo.point, Color.blue);

            if (Mathf.Abs(Owner.ActorTrans.transform.position.x - hitInfo.point.x) < 0.5f)
                return true;
        }

        return false;
    }

    void PlayerMove()
    {
        m_fHorizontal = Input.GetAxis("Horizontal");//获取Z轴方向移动指令
        //m_fVertical = Input.GetAxis("Vertical");//获取Y轴方向移动指令
        switch (cc.CamMoveDir)
        {
            case eCamMoveDir.CamMove_Left:
            case eCamMoveDir.CamMove_Right:
                {

                    if (0f == m_fHorizontal)
                    {
                        Owner.AM.SetFloat(NameToHashScript.SpeedId, 0f);
                        if (m_ePlayerState < ePlayerState.PlayerState_SmallJump)
                            m_ePlayerState = ePlayerState.PlayerState_Idle;
                    }
                    else

                    {

                        if (m_ePlayerState == ePlayerState.PlayerState_Idle)
                            m_ePlayerState = ePlayerState.PlayerState_Run;

                        Owner.AM.SetFloat(NameToHashScript.SpeedId, 1f);
                        m_vCurForward = new Vector3(m_fHorizontal, 0f, 0f);
                        Owner.ActorTrans.forward = Vector3.Lerp(Owner.ActorTrans.forward, m_vCurForward, 60 * Time.deltaTime);

                        if (cc.CamMoveDir == eCamMoveDir.CamMove_Right)
                        {
                            //block left
                            if (Owner.ActorTrans.transform.position.x <= Owner.CameraContrl.LeftPoint.x + Owner.ActorSize && m_fHorizontal < 0f)
                            {
                                return;
                            }
                        }
                        else
                        {
                            //block right
                            if (Owner.ActorTrans.transform.position.x >= Owner.CameraContrl.RightPoint.x - Owner.ActorSize && m_fHorizontal > 0f)
                            {
                                return;
                            }
                        }

                    
                        if (RayCastBlock(cc.CamMoveDir))
                            return;
                   
                        Owner.ActorTrans.Translate(new Vector3(0f, 0f, 3 * Time.deltaTime));

//                        if (m_ePlayerState < ePlayerState.PlayerState_SmallJump)
//                        {
//                            if (Physics.Raycast(Owner.ActorTrans.transform.position, Vector3.down, out hitInfo, dist, mask))
//                            {
//                                //绘制射线
//#if UNITY_EDITOR
//                                Debug.DrawLine(Owner.ActorTrans.transform.position, hitInfo.point, Color.red);
//#endif
//                                if (Mathf.Abs(Owner.ActorTrans.transform.position.y - hitInfo.point.y) > 0.4f)
//                                {
//                                    bDescent = true;
//                                    m_ePlayerState = ePlayerState.PlayerState_SmallJump;
//                                }
                              
//                            }
//                        }

                   }

                    break;
                }
            case eCamMoveDir.CamMove_Up:
            case eCamMoveDir.CamMove_Down:
                {
                    //Block Left and Block right

                    //不处理相机中点
                    break;
                }
        }
    }

    #endregion

    #region jump

    bool CanJump()//判定是否可以跳跃
    {
        if (m_ePlayerState < ePlayerState.PlayerState_SmallJump)
            return true;

        return false;
    }

    bool IsTriggerJump()
    {
        if (Input.GetKeyDown(KeyCode.K))
            return true;
        return false;
    }

    float JumpHeight = 3f;
    float JumpDuration = 0.5f;
    float JumpAcceleration = 10f;
    float OrigHeight = 0f;
    float CurHeight = 0f;
    bool bDescent = false;
    float CurAcceleration = 0f;
    void DoBeforeJump()
    {
        m_ePlayerState = ePlayerState.PlayerState_SmallJump;
        OrigHeight = Owner.ActorTrans.position.y;
        CurHeight = OrigHeight;
        bDescent = false;
        CurAcceleration = JumpAcceleration;
        Owner.RB.isKinematic = true;
    }

    void DoBeforeLeaveJump(float y)
    {
        bDescent = false;
        m_ePlayerState = ePlayerState.PlayerState_Idle;
        Owner.ActorTrans.position = new Vector3(
               Owner.ActorTrans.position.x,
               y,
               Owner.ActorTrans.position.z
             );
    }

    bool HitGround()
    {
        if (
            (m_ePlayerState >= ePlayerState.PlayerState_SmallJump/*当前在跳跃状态*/ && bDescent/*当前正在下降*/)
            )
        {
            if (Physics.Raycast(Owner.ActorTrans.transform.position, Vector3.down, out hitInfo, dist, mask))
            {
                //绘制射线
#if UNITY_EDITOR
                Debug.DrawLine(Owner.ActorTrans.transform.position, hitInfo.point, Color.red);
#endif
                //Debug.Log(Mathf.Abs(Owner.ActorTrans.transform.position.y - hitInfo.point.y));
                
                if (Mathf.Abs(Owner.ActorTrans.transform.position.y - hitInfo.point.y) < 0.2f)
                {
                    DoBeforeLeaveJump(hitInfo.point.y);
                    //Debug.Log("HitGround");
                    return true;
                }
            }
        }

        return false;
    }

    void JumpBehaviour()
    {

        //判定当前是否可以跳跃 <当前的状态>
        if (CanJump())
        {
            if (IsTriggerJump())
            {
                DoBeforeJump();
            }
        }

        //如果当前是跳跃状态
        if (m_ePlayerState >= ePlayerState.PlayerState_SmallJump)
        {
            if (CurHeight - OrigHeight >= JumpHeight)//判断是否跳到了最大高度
            {
                bDescent = true;
                Owner.RB.isKinematic = false;
            }
            else
            {
                CurHeight += (CurAcceleration * Time.deltaTime);

                Owner.ActorTrans.position = new Vector3(
                      Owner.ActorTrans.position.x,
                      CurHeight,
                      Owner.ActorTrans.position.z
                    );
            }

         
        }
    }

    #endregion

    #region old version 跳跃<跳跃永远是从小跳跃开始的>
    //bool m_bIsDescend = false;    //判断是否在下落状态
    //float m_fStartJumpTime = 0f;//开始计时变量
    //float m_fOrigHeight = 0f;//角色原始高度
    //float curPercent = 0f;//曲线进度
    //JumpDataStore m_CurJumpData;//跳跃数据
    //void BeginSmallJump()
    //{
    //    //保存原始高度
    //    m_fOrigHeight = Owner.ActorTrans.position.y;
    //    //保存曲线开始时间
    //    m_fStartJumpTime = Time.time;
    //    //判定是否开始下降
    //    m_bIsDescend = false;
    //    //获取小跳跃数据
    //    m_CurJumpData = Owner.SmallJumpDataStore;
    //    m_CurJumpData.m_CurDuration = m_CurJumpData.m_fSmallDuration;
    //    m_CurJumpData.m_CurJumpHeight = m_CurJumpData.m_fSmallHeight;
    //    m_CurJumpData.m_CurCurve = m_CurJumpData.m_acSmallJump;
    //    Owner.RB.useGravity = false;
    //}//初始化跳跃数据

    //void OnTriggerEnter(Collider other)
    //{
    //    //如果碰到的是地面
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Ground")/*碰到的是地面*/ && m_ePlayerState >= ePlayerState.PlayerState_SmallJump/*当前在跳跃状态*/ && m_bIsDescend/*当前正在下降*/)
    //    {
    //        ResetJump(other.gameObject);
    //    }
    //}

    //void ResetJump(GameObject obj)
    //{
    //    Owner.RB.useGravity = true;
    //    curPercent = 0f;
    //    m_bIsDescend = false;
    //    m_fStartJumpTime = 0f;
    //    Owner.ActorTrans.transform.position = new Vector3(
    //                    Owner.ActorTrans.transform.position.x,
    //                    obj.transform.position.y,
    //                    Owner.ActorTrans.transform.position.z
    //                    );
    //    m_fOrigHeight = 0f;
    //    m_ePlayerState = ePlayerState.PlayerState_Idle;
    //    //Owner.RB.isKinematic = false;
    //}//复位跳跃数据

    //bool CanJump()
    //{
    //    if (m_ePlayerState < ePlayerState.PlayerState_SmallJump && m_fOrigHeight == 0f && m_fStartJumpTime == 0f && false == m_bIsDescend)
    //        return true;

    //    return false;
    //}//判断是否可以跳跃

    //bool CheckJumpOver()
    //{
    //    if (m_ePlayerState >= ePlayerState.PlayerState_SmallJump/*当前在跳跃状态*/ && m_bIsDescend/*当前正在下降*/)
    //    {
    //        if (Owner.ActorTrans.position.y - m_fOrigHeight < 0.05f)
    //            return true;
    //    }
    //    return false;
    //}//判断是否跳跃结束

    //bool IsTriggerJump()
    //{
    //    if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K)) {
    //        m_ePlayerState = ePlayerState.PlayerState_SmallJump;
    //        return true;
    //    } 
    //    else if (Input.GetKeyDown(KeyCode.I)) {
    //        m_ePlayerState = ePlayerState.PlayerState_BigJump;
    //        return true;
    //    }
    //    return false;
    //}//判断是否触发了跳跃

    
    //void JumpBehaviour()
    //{

    //    if (CanJump())//检测是否可以开始跳跃
    //    {
    //        if (IsTriggerJump())//检测是否触发跳跃
    //        {
    //            BeginSmallJump();//初始化小跳跃数据 
    //        }
    //    }

    //}//跳跃行为接口


    #endregion

    #region 捡起箱子
    void PickUpBox()
    {

    }
    #endregion
}





//void JumpBehaviour()
//{

//    if (CanJump())//检测是否可以开始跳跃
//    {
//        if (IsTriggerJump())//检测是否触发跳跃
//        {
//            BeginSmallJump();//初始化小跳跃数据 
//        }
//    }


//    //if (Input.GetKey(KeyCode.I))
//    //{

//    //    if (curPercent >= 0.3f && m_bBigJumpFirstHoldKey == true && m_bIsDescend == false)
//    //    {
//    //        BeginBigJump();
//    //    }

//    //}

//    if (m_ePlayerState >= ePlayerState.PlayerState_SmallJump && curPercent <= 1.0f)//判定当前状态
//    {
//        curPercent = (Time.time - m_fStartJumpTime) / m_CurJumpData.m_CurDuration;//获取曲线进度
//        //计算当前角色高度
//        Owner.ActorTrans.transform.position = new Vector3(
//        Owner.ActorTrans.transform.position.x,
//        m_fOrigHeight + m_CurJumpData.m_CurCurve.Evaluate(curPercent) * m_CurJumpData.m_CurJumpHeight,
//        Owner.ActorTrans.transform.position.z
//        );

//        if (curPercent > 0.5f)//判断是否在下落状态
//            m_bIsDescend = true;
//    }

//}//跳跃行为接口


//void TouchHandler()
//{

//}

//void MouseHandler()
//{

//    m_fHorizontal = Input.GetAxis("Horizontal");//获取Z轴方向移动指令
//    if (m_ePlayerState <= ePlayerState.PlayerState_Run && 0f != m_fHorizontal)//如果当前非跳跃状态&&出发了移动指令 -> 切换状态到移动
//    {
//        m_ePlayerState = ePlayerState.PlayerState_Run;
//    }
//    else if (m_ePlayerState <= ePlayerState.PlayerState_Run && 0f == m_fHorizontal)//如果当前是非跳跃状态&&没有发出移动指令 -> 切换状态到待机
//    {
//        m_ePlayerState = ePlayerState.PlayerState_Idle;
//    }

//}

    //void BeginBigJump()
    //{
    //    //判定是否开始下降
    //    m_bIsDescend = false;
    //    //获取跳跃数据
    //    m_CurJumpData = Owner.SmallJumpDataStore;
    //    m_CurJumpData.m_CurDuration = m_CurJumpData.m_fBigDuration;
    //    m_CurJumpData.m_CurJumpHeight = m_CurJumpData.m_fBigJumpHeight;
        
    //}
