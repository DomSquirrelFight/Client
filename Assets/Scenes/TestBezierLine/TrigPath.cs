using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigPath : MonoBehaviour {
    public GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        CubeActor ca = obj.GetComponent<CubeActor>();
        ca.ChangerMyPath();
    }
    private void Update()
    {
    }
}
