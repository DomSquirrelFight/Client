using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
    public class ActionTakeDamage : BaseAction
    {
        public StateID InjureType;

        public override void TrigAction()
        {

            BaseActor Defenser = DataStore.Owner;
            BaseActor Attacker = DataStore.Target;
            #region 计算伤害
            if (Defenser.BaseAtt.RoleInfo.CharacType == AttTypeDefine.eCharacType.Type_Major)                   //主角
            {
                //同步UI显示.

            }
            //计算主角得分
            else
            {
                if (null != Attacker)
                {
                    //Attacker.PlayerMgr.UISceneFight
                }
            }
            #endregion

            Defenser.FSM.SetTransition(InjureType);
        }
        
    }
}

