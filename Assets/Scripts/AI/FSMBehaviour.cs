using System.Collections;
using UnityEngine;

public class FSMBehaviour : MonoBehaviour {
    
    protected FSMSystem fsm;

    public StateID CurrentStateID
    {
        get
        {
            if (fsm != null)
            {
                return fsm.CurrentState.ID;
            }

            return StateID.NullStateID;
        }
    }

    protected BaseActor ba;
    protected virtual void MakeFSM ()
    {
        ba = gameObject.GetComponent<BaseActor>();
    }

    protected BaseActor target;
    public BaseActor Target
    {
        get
        {
            if (target != null)
                return target;
            else
            {
                if (null != ba && ba.BaseAtt.CharacSide == AttTypeDefine.eCharacSide.Side_Enemy)
                {
                    //target = GlobalHelper.g_GlobalLevel.Major;
                }
            }
            return target;
        }
        set
        {
            if (value != target)
                target = value;
        }
    }

    public bool IsInState(StateID id) {
        if (fsm == null) {
            return false;
        }
        return fsm.IsInState(id);
    }

    public virtual void SetTransition(StateID id, BaseActor owner = null) {
        if (fsm != null) {

            if (null != owner && StateID.Death != id)
            {
                if (owner.AM.IsInTransition(0))
                {
                    //Debug.LogFormat("FSMBehaviour SetTransition CurState ({0}), next State({1})", fsm.CurrentState, id);
                    return;
                }
                 
            }


            fsm.PerformTransition(id, target);
        }
    }
    int index = 0;
    protected void UpdateFSM() {
        if (fsm != null && fsm.CurrentState != null) {
            fsm.CurrentState.Reason(Target);
            fsm.CurrentState.Act(Target);
        }
    }

    //public void Flashing (BaseActor target)
    //{
    //    SkinnedMeshRenderer smr = target.actor.GetComponentInChildren<SkinnedMeshRenderer>();
    //    Texture t2d = smr.materials[0].mainTexture;
    //    if (t2d.name == target.m_OrigTex.name)
    //    {
    //        smr.materials[0].mainTexture = Resources.Load("Textures/1") as Texture2D;
    //        StartCoroutine(FlashingV1(smr, t2d));
    //    }
    //}

    //IEnumerator FlashingV1(SkinnedMeshRenderer smr, Texture t2d)
    //{
    //    {
           
    //        yield return new WaitForSeconds(0.06f);
    //        smr.materials[0].mainTexture = t2d;
    //    }
    //}

}
