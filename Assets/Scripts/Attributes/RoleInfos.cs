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

        public eCharacSide CharacSide;

        public eCharacType CharacType;

        public float fInitAccel;

        public eMonsterType MoveType;

        public float fJumpUpDuration;

        public float fInitJumpSpeed;

        public float fJumpHeight;

        public bool bFire;

        public int nTotalAP;
        
    }
}

