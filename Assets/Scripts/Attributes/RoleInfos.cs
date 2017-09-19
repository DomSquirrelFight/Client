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

        public eMonsterType MonsterType;

        public eMoveType MoveType;

        public float fInitAccel;

        public float fJumpUpDuration;

        public float fInitJumpSpeed;

        public float fJumpHeight;

        public bool bFire;

        public int nTotalAP;

        public float RoleMoveSpeed;                                                                 //角色移动速度

        public float RoleBackSpeed;                                                                  //角色后退速度

        public float RoleRotSpeed;                                                                    //角色旋转速度

        public void OnValidate()
        {
            if (CharacType == eCharacType.Type_Major)
            {
                MonsterType = eMonsterType.MonType_Null;
                MoveType = eMoveType.eMove_NULL;
            }
        }

    }
}

