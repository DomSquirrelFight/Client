using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class PassBehavior : MonoBehaviour {

    #region 成员变量
    //当前的pass的index值做保存
    int m_CurIndex;
    //保存当前pass的初始位置
    Vector3 m_tOrigPos;
    
    //保存select游戏对象
    GameObject m_oSelect;
    #endregion

    #region 外部接口
    public void OnStart(int index,GameObject obj)
    {
        m_tOrigPos = gameObject.transform.localPosition;
        m_CurIndex = index;
        m_oSelect = obj;
        
    }
    #endregion

    #region 系统接口
    private void Update()
    {
        
    }
    #endregion

    #region 拖动
    void OnDrag(Vector2 delta)
    {
        
        if(Global.dragstate==DragState.State_Drag)
        {
            //跟随鼠标移动
            gameObject.transform.localPosition += (Vector3)delta;
            //ChangeScale();
        }
        
    }
    void OnPress()
    {
        if(Vector3.Distance(gameObject.transform.position,m_oSelect.transform.position)<=1f)
        {
            gameObject.transform.localPosition = m_oSelect.transform.localPosition;
            Global.dragstate = DragState.State_Stop;
        }
        else
        {
            gameObject.transform.localPosition = m_tOrigPos;
        }
    }
    #endregion

    #region 控制scale

#endregion


}
