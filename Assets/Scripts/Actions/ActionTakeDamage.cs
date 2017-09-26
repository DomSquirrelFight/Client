using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
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
                AudioManager.PlayAudio(Defenser.gameObject, eAudioType.Audio_Skill, "Hurt");
            }
            //计算主角得分
            else
            {
                AudioManager.PlayAudio(Defenser.gameObject, eAudioType.Audio_Skill, "HitEnemy");
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

