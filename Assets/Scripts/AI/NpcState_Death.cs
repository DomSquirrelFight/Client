using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState_Death : FSMState
{
    PlayerManager PlayerMgr;
    public NpcState_Death(BaseActor owner, StateID id) : base(owner, id) {
        PlayerMgr = Owner.PlayerMgr;
    }

    Vector3 dir;
    
    public override void DoBeforeEntering(BaseActor target)
    {
        dir = Quaternion.AngleAxis(45f * Owner.HoldBoxDir.x, Vector3.forward) * Owner.HoldBoxDir;
        Owner.DestroyPhysics();
        if (Owner.HoldBoxTrans)
            UnityEngine.Object.Destroy(Owner.HoldBoxTrans.gameObject);
        Owner.AM.SetTrigger(NameToHashScript.DeathId);
    }

    public override void Reason(BaseActor target)
    {
        Owner.ActorTrans.Translate(dir * Owner.BaseAtt.RoleInfo.RoleMoveSpeed * Time.deltaTime * 5, Space.World);
    }


}



