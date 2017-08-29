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
    public void OnStart(BaseActor owner)
    {
        Owner = owner;
        cc = Owner.CameraContrl;
    }
    void Update()
    {

        if (!Owner) return;

        JumpBehaviour();//角色跳跃

        PlayerMove();//角色移动

        PickUpBox();//捡起箱子

    }
    #endregion

    #region 角色move
    float m_fHorizontal = 0f;
    float m_fVertical = 0f;
    Vector3 m_vCurForward = Vector3.zero;
    void PlayerMove()
    {
        m_fHorizontal = Input.GetAxis("Horizontal");//获取Z轴方向移动指令
        m_fVertical = Input.GetAxis("Vertical");//获取Y轴方向移动指令
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
                        Owner.ActorTrans.Translate(new Vector3(0f, 0f, 3 * Time.deltaTime));
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

    #region 小跳跃
    bool CanSmallJump()
    {
        if (m_ePlayerState < ePlayerState.PlayerState_SmallJump && m_fOrigHeight == 0f && m_fStartJumpTime == 0f && false == m_bIsDescend)
            return true;

        return false;
    }
    //判断是否在下落状态
    bool m_bIsDescend = false;

    bool IsDescend
    {
        get
        {
            return m_bIsDescend;
        }
    }
    float m_fStartJumpTime = 0f;//开始计时变量
    float m_fOrigHeight = 0f;//角色原始高度
    void BeginSmallJump()
    {
        //设置当前状态
        m_ePlayerState = ePlayerState.PlayerState_SmallJump;
        //保存原始高度
        m_fOrigHeight = Owner.ActorTrans.position.y;
        //保存曲线开始时间
        m_fStartJumpTime = Time.time;
        //判定是否开始下降
        m_bIsDescend = false;
    }

    void ResetJump()
    {
        m_bIsDescend = false;
        m_fStartJumpTime = 0f;
        Owner.ActorTrans.transform.position = new Vector3(
                        Owner.ActorTrans.transform.position.x,
                        m_fOrigHeight,
                        Owner.ActorTrans.transform.position.z
                        );
        m_fOrigHeight = 0f;
        m_ePlayerState = ePlayerState.PlayerState_Idle;
    }

    float curPercent = 0f;//曲线进度

    void OnTriggerEnter(Collider other)
    {
        //如果碰到的是地面
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")/*碰到的是地面*/ && m_ePlayerState >= ePlayerState.PlayerState_SmallJump/*当前在跳跃状态*/ && IsDescend/*当前正在下降*/)
        {
            ResetJump();
        }
    }

    void JumpBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.K))
        {
            if (CanSmallJump())
            {
                BeginSmallJump();
            }
        }

        switch (m_ePlayerState) {
            case ePlayerState.PlayerState_SmallJump:
                {
                    curPercent = (Time.time - m_fStartJumpTime) / Owner.SmallJumpDataStore.m_fDuration;
                    Owner.ActorTrans.transform.position = new Vector3(
                        Owner.ActorTrans.transform.position.x,
                        m_fOrigHeight + Owner.SmallJumpDataStore.m_acJump.Evaluate(curPercent) * Owner.SmallJumpDataStore.m_fHeight,
                        Owner.ActorTrans.transform.position.z
                        );

                    if (curPercent > 0.5f)
                        m_bIsDescend = true;
     
                    break;
                }
            case ePlayerState.PlayerState_BigJump:
                {
                    break;
                }
        }

    }
    #endregion

    #region 捡起箱子
    void PickUpBox()
    {

    }
    #endregion

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

}
