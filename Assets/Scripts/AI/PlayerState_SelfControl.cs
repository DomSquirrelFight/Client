﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_SelfControl : FSMState {

    public PlayerState_SelfControl(BaseActor owner)
    {
        Owner = owner;
        stateID = StateID.Idle;
    }






}
