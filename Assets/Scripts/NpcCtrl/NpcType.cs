using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Action;
public class NpcType :  BaseAction{

    public eMonsterType MonsterType = eMonsterType.MonType_Null;

    public string PrefabName;

    public int RoleId;
    
    public bool TriggerOnce = false;

    public PathArea area;


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
            case eMonsterType.MonType_GroundNpc:
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(transform.position,  0.5f);
                    break;
                }
        }
    }

    UnityEngine.Object obj;
    public void OnLoad(Object _obj)
    {
        if (!TriggerOnce)
            Reset();
        switch (MonsterType)
        {
            case eMonsterType.MonType_Rock:
                {
                    obj = _obj;
                    break;
                }
        }
        OnStart();
    }

    public override void TrigAction()
    {
        switch (MonsterType) {
            case eMonsterType.MonType_Rock:             //怪兽类型是陨石 -> 相当于直接释放技能
                {
                    GameObject _obj =  Instantiate(obj, transform.position, transform.rotation) as GameObject;
                    ActionInfos ai = _obj.GetComponent<ActionInfos>();
                    ai.SetOwner(_obj);
                    break;
                }
            case eMonsterType.MonType_GroundNpc:
                {
                    BaseActor ba = BaseActor.CreatePlayer(RoleId, transform.position, transform.rotation, Vector3.one);
                    ba.PlayerMgr.OnStart(ba, area);
                    if (TriggerOnce)
                    Destroy(gameObject);
                    break;
                }
        }
    }

}
