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

            Defenser.FSM.SetTransition(InjureType);
        }
        
    }
}

