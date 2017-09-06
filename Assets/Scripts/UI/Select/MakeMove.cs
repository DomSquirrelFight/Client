
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMove : MonoBehaviour {
    //ui和btn的移动分为两种，一种是在拖动的时候，根据drag的delta的值进行移动，还有一种是根据index值来确定的最终位置
    public  void MoveInDrag(Vector2 delta)
    {
        //移动ui
        Global.Grid.transform.localPosition += (Vector3)delta;
        //移动curbtn
        Global.CurBtn.transform.localPosition += new Vector3(-((Vector3)delta).x / 4, 0, 0);
    }
    public void MoveOutDrag(int index)
    {
        Global.Grid_CurrentIndex = index;
        //Global.Grid.transform.localPosition = Vector3.Lerp(Global.Grid.transform.localPosition, new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0), 5 * Time.deltaTime);
        Global.Grid.transform.localPosition = Vector3.Lerp(Global.Grid.transform.localPosition, new Vector3(-(index * Global.Grid_PerSize), 0, 0), 5 * Time.deltaTime);
        //Global.CurBtn.transform.localPosition = Vector3.Lerp(Global.CurBtn.transform.localPosition, Global.UI[Global.Grid_CurrentIndex].transform.localPosition, 5 * Time.deltaTime);
        Global.CurBtn.transform.localPosition = Vector3.Lerp(Global.CurBtn.transform.localPosition, Global.UI[index].transform.localPosition, 5 * Time.deltaTime);
    }
    public void MoveInmarginal(int index)
    {
        Global.Grid_CurrentIndex = index;
        Global.Grid.transform.localPosition = new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0);
        Global.CurBtn.transform.localPosition = Global.UI[Global.Grid_CurrentIndex].transform.localPosition;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
