using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class Inite : MonoBehaviour {
    //存放grid
    public GameObject Grid;
    //存放panelbutton
    public GameObject Button;
    // Use this for initialization
    void Awake () {
        InitePanel();
    }
    void InitePanel()
    {

        //把当前的grid存储在静态变量中
        Global.Grid = Grid;
        Global.Button = Button;
        
        Global.Grid_CurrentIndex = 0;
        Global.Scene_Go = "loading";

    }

}
