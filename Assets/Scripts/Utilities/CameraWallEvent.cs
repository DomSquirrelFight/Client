using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

[RequireComponent(typeof(BoxCollider))]
public class CameraWallEvent : MonoBehaviour {

    void Reset()
    {
        BoxCollider bc = gameObject.GetComponent<BoxCollider>();
        bc.isTrigger = true;
    }

    public bool BIsTriggerOnce = false;

    void OnTriggerEnter(Collider other)
    {

        //如果触发到的是相机
        if (other.gameObject.tag == "MainCamera")
        {
            //根据当前的运动朝向，阻挡指定的运动轨迹
            CameraController cc = other.gameObject.GetComponent<CameraController>();
            if (null == cc)
            {
                Debug.LogError("Fail to find CameraController");
                return;
            }

      

            if (BIsTriggerOnce)
                Destroy(gameObject);

        }
    }

}
