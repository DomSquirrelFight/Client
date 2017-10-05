using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathArea : MonoBehaviour {
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

        Vector3[] m_vCurPoints = new Vector3[pa.transform.childCount];

        for (int i = 0; i < pa.transform.childCount; i++)
        {
            m_vCurPoints[i] = pa.transform.GetChild(i).position;
        }

        return m_vCurPoints;

    }

}
