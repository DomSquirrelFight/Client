using UnityEngine;
namespace AttTypeDefine
{

    #region UI

    public enum LoadingState
    {
        e_LoadLevel,
        e_ProcessBar,
        e_LoadSelect,
        e_Null,
    }
    //通过不同的场景，预加载不同的资源
    public enum SceneType
    {
        SelecteLoading,
        Null,
        FightLoading,
    }

    //任务选择界面的，拖动，滑动
    public  enum StateUI
    {
        State_Move,
        State_Stay,
    }
    //动画的状态，用于loading界面
    public enum AnimState
    {
        Start_null,
        Start_BgAnim,
        Start_PicAnim,
        Start_ProgressBar,
    }
    #endregion

    #region Character Behaviour

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
        MonType_Pig,
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
    #endregion

}
