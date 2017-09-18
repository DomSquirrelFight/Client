using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.RoleInfoEditor
{
    public class RoleInfos : ScriptableObject
    {

        public int nRoleID;

        public string strRoleName;

        public string strRolePath;

        public eCharacSide CharacSide;

        public eCharacType CharacType;

        public float fInitAccel;

        public eMonsterType MoveType;

        public float fJumpUpDuration;

        public float fInitJumpSpeed;

        public float fJumpHeight;

        public bool bFire;

        public int nTotalAP;

        public float RoleMoveSpeed;                                                                 //角色移动速度

        public float RoleBackSpeed;                                                                  //角色后退速度

        public float RoleRotSpeed;                                                                    //角色旋转速度



        
    }
}

