using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class NpcType : MonoBehaviour {

    public eMonsterType MonsterType = eMonsterType.MonType_Null;

    public string PrefabName;

    void OnDrawGizmos()
    {
        switch (MonsterType)
        {
            case eMonsterType.MonType_Rock:
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(transform.position, Vector3.one * 0.5f);
                    break;
                }
        }
    }

}
