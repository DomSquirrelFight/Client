using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class NpcTriggerWall : MonoBehaviour {

    void Reset()
    {
        BoxCollider bc = gameObject.GetComponent<BoxCollider>();
        bc.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        BaseActor ba = null;
        //找到major baseactor
        if (null != (ba = (other.transform.parent.GetComponent<BaseActor>())))
        {
            if (ba.Actor.layer == LayerMask.NameToLayer("NPC") && ba.BaseAtt.CharacType == AttTypeDefine.eCharacType.Type_Major && ba.BaseAtt.CharacSide == AttTypeDefine.eCharacSide.Side_Player)
            {
                //遍历所有的孩子，然后实例化指定的对象
                for (int i = 0; i < transform.childCount; i++)
                {
                    NpcType nt = transform.GetChild(i).GetComponent<NpcType>();
                    switch (nt.MonsterType)
                    {
                        case AttTypeDefine.eMonsterType.MonType_Rock:
                            {
                                UnityEngine.Object obj = Resources.Load("IGSoft_Projects/Rocks/RockSkill/" + nt.PrefabName);
                                nt.OnLoad(obj);
                                Debug.Log(1);
                                break;
                            }
                    }
                }
            }
        }
     
    }


  
    
}
