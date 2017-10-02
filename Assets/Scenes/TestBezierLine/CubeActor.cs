using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActor : MonoBehaviour {

    float he;
    Vector2 input;
    BezierLine bl;
    string path;
    float speed;
    public GameObject trigger;
    void Start () {
  
   
        path = "Prefabs/Paths/Line0";
        bl = gameObject.AddComponent<BezierLine>();
        speed = 5f;
       // gameObject.transform.position = Vector3.zero;
    }

    #region 输入
    void GetInput()
    {
        he = Input.GetAxis("Horizontal");
        if (he > 0)
        {
            input.x = 1;
        }
        else if (he < 0)
        {
            input.x = -1;
        }
        else
            input.x = 0;
    }
    #endregion

    void Update () {
        
        GetInput();
<<<<<<< HEAD
      //  bl.RotatePlayerAlongBezier(path, gameObject, input, speed);
=======
        //bl.RotatePlayerAlongBezier(path, gameObject, input, speed);
>>>>>>> master
	}
    private void OnTriggerEnter(Collider other)
    {

    }
    public void  ChangerMyPath()
    {
        path = "Prefabs/Paths/Line1";
    }
}
