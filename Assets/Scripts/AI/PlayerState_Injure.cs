using Assets.Scripts.Utilities;
using UnityEngine;
public class PlayerState_Injure : FSMState_InjureBase {

    public PlayerState_Injure(BaseActor owner)
        : base(owner, StateID.Injured)
    {
    }
    bool bLastInTransition = false;
    float RoleBackSpeed = 0f;
    public override void DoBeforeEntering(BaseActor target)
    {
        Owner.RB.isKinematic = true;
        Owner.BC.enabled = false;
        RoleBackSpeed = Owner.BaseAtt.RoleInfo.RoleBackSpeed;
        Owner.AM.SetTrigger(NameToHashScript.InjuredId);
        Owner.StartChangingAlpha();
    }

    public override void Reason(BaseActor target)
    {
        bool intransition = Owner.AM.IsInTransition(0);
        Owner.ActorTrans.Translate(Owner.ActorTrans.forward * (-1f) * RoleBackSpeed * Time.deltaTime, Space.World);
        if (bLastInTransition && !intransition)
        {
            Owner.RB.isKinematic = false;
            Owner.BC.enabled = true;
            Owner.EndChangingAlpha();
            Owner.FSM.SetTransition(StateID.Idle);
        }
        bLastInTransition = intransition;
    }
}
