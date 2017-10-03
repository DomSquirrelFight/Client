using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.AssetInfoEditor
{
    [System.Serializable]
    public class RoleBehavInfos : ScriptableObject
    {
        
        public int RoleID;

        public bool CanFire;                //是否可以开火

        public bool CanPickUpBox;     //是否可以举箱子

        public float RoleMoveSpeed;

        public float RoleInjureBackSpeed;

        public eRunMode RunMode = eRunMode.eRun_Horizontal;

        public bool CanSmallJump;        //是否可以跳跃
        public float SmallJumpHeight;    //跳跃高度
        public float SmallJumpInitSpeed; //跳跃初速度
        public float SmallJumpAccel;     //跳跃加速度
        public float SmallJumpUpDuration;  //上跳持续时间.

        public bool CanBigJump;        //是否可以跳跃
        public float BigJumpHeight;    //跳跃高度
        public float BigJumpInitSpeed; //跳跃初速度
        public float BigJumpAccel;     //跳跃加速度
        public float BigJumpUpDuration;  //上跳持续时间.


    }
}

