using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class SwitchRunInfosDoor : MonoBehaviour {

    public eRunMode Mode = eRunMode.eRun_Horizontal;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))     //如果撞到们的是npc
        {
            BaseActor ba = other.transform.parent.GetComponent<BaseActor>();
            ba.SetCurRoleBehavInfos(Mode);
            Destroy(gameObject);
        }
    }
}
