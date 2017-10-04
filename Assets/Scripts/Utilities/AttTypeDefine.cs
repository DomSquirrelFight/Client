﻿using UnityEngine;
namespace AttTypeDefine
{

    #region UI


    public enum DragState       //ZL
    {
        State_Drag,
        State_Stop,
    }


    public enum eAudioType
    {
        Audio_Skill,
        Audio_BackGround,
        Audio_UI,
    }

    public enum LoadingState
    {
        e_LoadLevel,
        e_ProcessBar,
        e_StartTime,
        e_Null,
    }

    ////通过不同的场景，预加载不同的资源
    //public enum SceneType
    //{
    //    SelecteLoading,
    //    Null,
    //    FightLoading,
    //}

    //任务选择界面的，拖动，滑动
    public  enum StateUI
    {
        State_Move,
        State_Stay,
    }
    //动画的状态，用于loading界面
    public enum AnimState
    {
        State_null,
        State_BgAnim,
        State_PicAnim,
        State_ProgressBar,
    }
//<<<<<<< HEAD
//<<<<<<< HEAD
//    //用于在关卡选择界面 判断是不是可以移动pass
//    public enum DragState
//=======
 // 关卡选择中判断是不是可以拖动
// public enum DragState
////>>>>>>> master
//    {
//        State_Drag,
//        State_Stop,
//    }
//=======
//    //用于判断双击
//    //public enum ClickState
//    //{
//    //    Click_First,
//    //    Click_Scecond,
//    //    Click_Null,
//    //}
//>>>>>>> master
    #endregion

    #region Character Behaviour

    public enum eMoveType
    {
        eMove_NULL,
        eMove_Straight,
        eMove_Track,
    }
    
    public enum eCoutTimeType
    {
        CountType_Auto,
        CountType_Condition,
    }
    public enum eRockBehaviour
    {
        Rock_Fire,//沿指定路径发射
        Rock_Track,//追踪
        Rock_TriggerAround,//在出生地四周发射
        Rock_Popup,//弹射
    }

    public enum eCharacType
    {
        Type_Major,
        Type_NormalNpc,
        Type_Boss,
    }

    public enum eCharacSide
    {
        Side_Player,
        Side_Enemy,
        Side_Neutral,
    }

    public enum eMonsterType
    {
        MonType_Null = -1,
        MonType_Rock,
        MonType_FlyBat,
        MonType_GroundNpc,
        MonType_FakeBox,
        MonType_Size,
    }

    public enum ePlayerNormalBeha
    {
        eNormalBehav_NULL,//
        eNormalBehav_Grounded,
        eNormalBehav_SmallJump,
        eNormalBehav_BigJump,
        eNormalBehav_JumpDown,
        eNormalBehav_Hide,

        //eNormalBehav_Move,
        //eNormalBehav_Idle,
    }

    public enum ePlayerJumpDownState
    {
        CanJumpDown_NULL,
        CanJumpDown_YES,
        CanJumpDown_NO,
    }

    public enum eRoleID
    {
        Role_NULL = -1,
        Role_Major = 101,
        Role_SoliderV1 = 201,
    }

    public struct CamBorderPosition//确定相机的四个边界位置
    {
        public Vector3 LeftBorderPos;
        public Vector3 RightBorderPos;
        public Vector3 TopBorderPos;
        public Vector3 BottomBorderPos;
    }

    public enum eCamMoveDir
    {
        CamMove_Null = -1,
        CamMove_Left,
        CamMove_Right,
        CamMove_Up,
        CamMove_Down,
    }
#endregion

    #region Camera

    public delegate void NotifyCamContrl (int index);           //通知相机管理器，当前状态已经结束

    public enum eCameStates
    {
        eCam_NULL,
        eCam_Birth,             //出生相机
        eCam_RPGFollow,
        eCam_SLGFollow,
        eCam_Zoom,          //缩进，缩远
        eCam_Dead,          //死亡相机
    }


    public enum eCamFourCorner
    {
        CamCorner_UpperLeft,
        CamCorner_UpperRight,
        CamCorner_DownLeft,
        CamCorner_DownRight,
        CamCorner_Size,
    }

    public enum eTargetFourCorner
    {
        TargetCorner_Left,
        TargetCorner_Right,
        TargetCorner_Up,
        TargetCorner_Down,
        TargetCorner_Size,
    }

    #endregion

    #region Delegate    
    public delegate void NotifyEvent (GameObject obj);
    public delegate void DelEventSkillReady();
    public delegate void DelNotifySkill();
    #endregion

    #region Skill
    public enum eStateBehaType
    {
        State_AnimBegin,
        State_AnimEnd,
    }

    public enum eSkillType
    {
        SkillType_ThrowBox = 0,                                                 //扔盒子
        SkillType_FireBullet,                                                  //发射子弹
        SkillType_SummonMonster,                                      //召唤怪兽
    }
    #endregion

    #region Attribute

    public enum eAttInfo
    {
        AttInfo_HP = 0,
        AttInfo_Mp,
        AttInfo_Size,
    }

    #endregion

    #region way finding
    public enum eBezierLineConstrainedMode
    {
        Free,
        Mirror,
    };

    public enum eWayFinding
    {
        eWayFind_NULL,
        eWayFind_PathLastPoint,
    }


    public enum eWallEvent
    {
        eWallEvent_ChoosePath,
    }


    #endregion

    #region Role Behaviour

    public enum eRunMode
    {
        eRun_Horizontal,
        eRun_Vertical,
    }

    public struct sRoleBehaviour            //保存角色行为参数
    {

        public eRunMode RunMode;                    //跑步模式

        public sRoleJump HorizontalJump;            //横向跳跃

        public sRoleJump VerticalSmallJump;       //纵向小跳

        public sRoleJump VerticalBigJump;           //纵向大条

        public bool CanFire;                //是否可以开火

        public bool CanPickUpBox;     //是否可以举箱子

        public float RoleMoveSpeed;

        public float RoleRotSpeed;

        public float RoleInjureBackSpeed;

    }

    public struct sRoleJump
    {

        public sRoleJump(float fInitAccel/*跳跃加速度*/, float _fJumpUpDuration/*上跳时长*/)
        {
            CanJump = false;
            JumpAccel = fInitAccel;
            JumpUpDuration = _fJumpUpDuration;
            JumpHeight = (JumpInitSpeed = GlobalHelper.CalculateInitSpeed(fInitAccel, _fJumpUpDuration)) * _fJumpUpDuration + 0.5f * fInitAccel * _fJumpUpDuration * _fJumpUpDuration;
        }

        public bool CanJump;        //是否可以跳跃
        public float JumpHeight;    //跳跃高度
        public float JumpInitSpeed; //跳跃初速度
        public float JumpAccel;     //跳跃加速度
        public float JumpUpDuration;  //上跳持续时间.
    }


    #endregion

}
