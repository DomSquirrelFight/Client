using UnityEngine;
using AttTypeDefine;

public class MakeMove : MonoBehaviour {
    //ui和btn的移动分为两种，一种是在拖动的时候，根据drag的delta的值进行移动，还有一种是根据index值来确定的最终位置
    public  void MoveInDrag(Vector2 delta)
    {
        //移动ui
        Global.Grid.transform.localPosition += new Vector3(((Vector3)delta).x,0,0);
        //移动curbtn
        Global.CurBtn.transform.localPosition += new Vector3(-((Vector3)delta).x / 4, 0, 0);
        Debug.Log("delta.x="+delta.x);
        Debug.Log("Position="+Global.Grid.transform.localPosition);
    }
    public void MoveOutDrag(int index)
    {
 
        //Global.Grid.transform.localPosition = Vector3.Lerp(Global.Grid.transform.localPosition, new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0), 5 * Time.deltaTime);
        Global.Grid.transform.localPosition = Vector3.Lerp(Global.Grid.transform.localPosition, new Vector3(-(index * Global.Grid_PerSize), 0, 0), 2 * Time.deltaTime);
        //Global.CurBtn.transform.localPosition = Vector3.Lerp(Global.CurBtn.transform.localPosition, Global.UI[Global.Grid_CurrentIndex].transform.localPosition, 5 * Time.deltaTime);
        Global.CurBtn.transform.localPosition = Vector3.Lerp(Global.CurBtn.transform.localPosition, Global.UI[index].transform.localPosition,2*Time.deltaTime);
    }
    public void MoveInmarginal(int index)
    {
        Global.Grid.transform.localPosition = new Vector3(-(index * Global.Grid_PerSize), 0, 0);
        Global.CurBtn.transform.localPosition = Global.UI[index].transform.localPosition;
    }
    protected virtual void Update () {
        if (Global.e_State == StateUI.State_Move)
        {
            MoveOutDrag(Global.Grid_CurrentIndex);
        }
        if ((Mathf.Abs(Global.Grid.transform.localPosition.x + (Global.Grid_CurrentIndex * Global.Grid_PerSize))) < 10f)
        {
            Global.e_State = StateUI.State_Stay;
        }
    }
}
