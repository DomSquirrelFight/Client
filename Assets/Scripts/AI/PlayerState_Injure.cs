using Assets.Scripts.Utilities;
using UnityEngine;
public class PlayerState_Injure : FSMState_InjureBase {

    public PlayerState_Injure(BaseActor owner)
        : base(owner, StateID.Injured)
    {
    }
    bool bLastInTransition = false;
    public override void DoBeforeEntering(BaseActor target)
    {
        base.DoBeforeEntering(target);
        Owner.AM.SetTrigger(NameToHashScript.InjuredId);
    }

    public override void Reason(BaseActor target)
    {
        bool intransition = Owner.AM.IsInTransition(0);
        Owner.ActorTrans.Translate(Owner.ActorTrans.forward * (-1f) * GlobalHelper.SBackSpeed * Time.deltaTime, Space.World);
        if (bLastInTransition && !intransition)
        {
            Owner.FSM.SetTransition(StateID.Idle);
        }
        bLastInTransition = intransition;
    }
}
