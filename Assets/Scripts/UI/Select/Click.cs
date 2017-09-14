using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    int btnindex;
    public void OnStart(int index)
    {
        btnindex = index;
        UIEventListener.Get(Global.UI[index]).onClick = ChangeIndex;
    }

    void ChangeIndex(GameObject obj)
    {
        //根据当前btn的index的值，移动grid
        //对应index
        Global.Grid_CurrentIndex = btnindex;
        Debug.Log(Global.Grid_CurrentIndex);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
