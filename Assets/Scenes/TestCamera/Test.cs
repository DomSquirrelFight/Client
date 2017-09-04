using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DT.Assets.CameraController;
public class Test : MonoBehaviour {

    public Transform Target;

    void Awake()
    {
        TestCamera tc = Camera.main.gameObject.GetComponent<TestCamera>();
        tc.OnStart(Target);
    }

}
