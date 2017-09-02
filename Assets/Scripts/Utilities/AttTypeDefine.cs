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
    public enum SceneType
    {
        SelecteLoading,
        FightLoading,
    }
    #endregion

    #region Character Behaviour
    public enum ePlayerBehaviour
    {
        eBehav_Normal,//平移，待机，小跳跃，大跳跃，仍箱子，捡箱子
        eBehav_Hide,//隐藏
        eBehav_JumpDown,//往下跳
    }

    public enum ePlayerNormalBeha
    {
        eNormalBehav_Grounded,
        eNormalBehav_SmallJump,
        eNormalBehav_BigJump,
        //eNormalBehav_Move,
        //eNormalBehav_Idle,
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
    public enum ePlayerState
    {
        PlayerState_Idle,//待机
        PlayerState_Run,//奔跑
        PlayerState_SmallJump,//小跳
        PlayerState_BigJump,//大跳  
    }

    public enum eCameEventType
    {
        CamEvent_ChangeDir,//改变运动方向
    }
    
    public enum eCameraBorderSide
    {
        CameraSide_Left,
        CameraSide_Right,
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
    
}
