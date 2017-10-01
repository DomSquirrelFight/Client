using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathArea : MonoBehaviour {
    public Transform[] RoutePoints;
    public PathArea[] NextAreas;
    //public Transform[] LinkAreaPoints;
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position + Vector3.up,  Vector3.one);
#if UNITY_EDITOR
        //Handles.color = Color.white;
        //Handles.Label(transform.position + Vector3.up, index.ToString());
#endif
    }

    public static Vector3[] GetVectorArray(PathArea pa)
    {
        Vector3[]  m_vCurPoints = new Vector3[pa.RoutePoints.Length];

        for (int i = 0; i < m_vCurPoints.Length; i++)
        {
            m_vCurPoints[i] = pa.RoutePoints[i].transform.position;
        }

        return m_vCurPoints;

    }

}
