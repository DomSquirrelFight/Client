using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigChange : MonoBehaviour {
    public GameObject m_Cube;

    private void OnTriggerEnter(Collider other)
    {
        CubeActor ca = m_Cube.GetComponent<CubeActor>();
        ca.ChangerMyPath();
    }
}
