using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : FSMBehaviour
{
    // Use this for initialization
    void Start()
    {
        MakeFSM();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFSM();
    }

    protected override void MakeFSM()
    {
        base.MakeFSM();
        fsm = new FSMSystem();

        NpcState_Idle idle = new NpcState_Idle(ba, StateID.Idle);
        idle.AddTransition(StateID.Chase);


        NpcState_Chase chase = new NpcState_Chase(ba, StateID.Chase);
        chase.AddTransition(StateID.Idle);
            
        fsm.AddState(idle);
        fsm.AddState(chase);
    }
}
