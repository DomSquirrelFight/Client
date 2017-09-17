using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_SelfControl : FSMState {

    public PlayerState_SelfControl(BaseActor owner)
    {
        Owner = owner;
        stateID = StateID.Idle;
    }



    //public override void DoBeforeLeaving(BaseActor target)
    //{
    //    if (null == Owner.SkillMgr.CurSkillBase)
    //        return;
    //    List<GameObject> effects = Owner.SkillMgr.CurSkillBase.EffectList;
    //    while (effects.Count > 0)
    //    {
    //        GameObject obj = effects[0];
    //        if (null != obj)
    //        {
    //            NcAutoDestruct.CreateAutoDestruct(obj, 0, 0, false, false);
    //        }
    //        effects.RemoveAt(0);
    //    }
    //}



}
