using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities;

public class FSMState_InjureBase : FSMState {
    public FSMState_InjureBase(BaseActor owner, StateID id)
    {
        stateID = id;
        Owner = owner;
    }
}
