using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigClick : MakeMove {
    int ClickIndex;
    public bool IsEnd = false;
    public void OnStart(int index)
    {
        ClickIndex = index;
        UIEventListener.Get(gameObject).onClick = ClickBtn;
    }
    void ClickBtn(GameObject obj)
    {
        IsEnd = true;
        Debug.Log("Click"+ClickIndex);
        //根据传入的index值，改变当前的index值
        //Global.Grid_CurrentIndex = ClickIndex;
        //MoveOutDrag(ClickIndex);
        //MoveInmarginal(ClickIndex);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(IsEnd)
        {
            Debug.Log(ClickIndex);
            MoveOutDrag(ClickIndex);
        }
        if ((Mathf.Abs(Global.Grid.transform.localPosition.x + (Global.Grid_CurrentIndex * Global.Grid_PerSize))) < 0.5f)
        {
            IsEnd = false;
        }
        
    }
}
