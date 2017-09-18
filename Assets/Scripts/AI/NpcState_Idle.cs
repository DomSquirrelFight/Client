using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState_Idle : FSMState
{

    public NpcState_Idle(BaseActor owner)
    {
        Owner = owner;
        stateID = StateID.Idle;
    }
}
