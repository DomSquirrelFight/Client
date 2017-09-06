using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniteBtn : MakeMove {

    public GameObject[] Btn;
    public string path;
    void Start()
    {
        Global.UI = new GameObject[Btn.Length];
        for (int i = 0; i < Btn.Length; i++)
        {
            //Btn初始化
            GameObject button = Btn[i];
            button.transform.parent = Global.Button.transform;
            button.transform.localScale = new Vector3(2, 0.5f, 1);
            Global.UI[i] = Btn[i];
            TrigClick tc = Btn[i].AddComponent<TrigClick>();
            tc.OnStart(i);
            
        }

        //初始化当前选中的button的位置
        GameObject CurButton = Instantiate(Resources.Load(path)) as GameObject;
        CurButton.transform.parent = Global.Button.transform;
        CurButton.transform.localPosition = Btn[0].transform.localPosition;
        CurButton.transform.localScale = Vector3.one;
        Global.CurBtn = CurButton;
        //UIEventListener.Get(Btn[BtnIndex]).onClick = Click;
        //UIEventListener.Get(obj).onClick = Click;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
