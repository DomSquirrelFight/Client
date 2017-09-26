using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PathPoint : MonoBehaviour {

    public Transform[] Points;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawWireSphere(transform.position, .25f);
#if UNITY_EDITOR
        //Handles.color = Color.white;
        //Handles.Label(transform.position + Vector3.up, index.ToString());
#endif
    }

}
