using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using AttTypeDefine;

public class PathPoint : MonoBehaviour {

    public eWayFinding WayFinding = eWayFinding.eWayFind_NULL;


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))     //如果撞到们的是npc
    //    {
    //        //Block.gameObject.SetActive(true);

    //        //BaseActor ba = other.transform.parent.GetComponent<BaseActor>();

    //        ////重新规划路线
    //        //ba.PlayerMgr.ReCalculateRoute();

    //        Destroy(bc);
    //    }
    //}

    void OnDrawGizmos()
    {
        switch (WayFinding)
        {
            case eWayFinding.eWayFind_NULL:
                {
                    Gizmos.color = Color.white;
                    break;
                }
            case eWayFinding.eWayFind_PathLastPoint:
                {
                    Gizmos.color = Color.blue;
                    break;
                }
        }
        
        
        Gizmos.DrawWireSphere(transform.position, .25f);
    }

}
