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

        NpcState_Idle idle = new NpcState_Idle(ba);

        //PlayerState_SelfControl con = new PlayerState_SelfControl(ba);
        //con.AddTransition(StateID.Injured);

        //PlayerState_Injure injure = new PlayerState_Injure(ba);
        //injure.AddTransition(StateID.Injured);
        //injure.AddTransition(StateID.Idle);

        fsm.AddState(idle);
        //fsm.AddState(injure);
    }
}
