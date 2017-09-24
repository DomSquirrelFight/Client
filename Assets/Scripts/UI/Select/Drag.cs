using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class Drag : MakeMove {
    #region bool值的成员变量
    //是否触摸
    bool IsTouch = false;
    //是否在滑动
    bool IsDrag = false;
    //是否是向右滑动
    bool IsRight = false;
    //是否是向左滑动
    bool IsLeft = false;
    //是不是点击时刻
    bool IsClick = true;
    //是否确定最终位置
    bool IsFinalPos;

    #endregion

    #region 通过判断drag来改变ui的位置
    //存储delta
    Vector3 drag;
    //记录grid的原始位置
    Vector3 Pos;
    #region 拖拽中的判定
    void OnDrag(Vector2 delta)
    {
        drag = delta;
        if (!IsTouch)
        {

            if (delta.x > 0.5f)
            {
                IsRight = true;
                IsDrag = true;
            }
            else if (delta.x < -0.5f)
            {
                IsLeft = true;
                IsDrag = true;
            }
            IsTouch = true;
        }
        //根据当前移动的dalta来移动ui和btn的位置
        MoveInDrag(delta);
        ////移动ui
        //Global.Grid.transform.localPosition += (Vector3)delta;
        ////移动curbtn
        //Global.CurBtn.transform.localPosition += new Vector3(-((Vector3)delta).x / 4, 0, 0);
    }
    #endregion

    #region 拖拽结束之后的判定
    void OnPress()
    {
        if (IsClick)
        {
            Pos = Global.Grid.transform.localPosition;
            IsClick = false;
        }
        else
        {
            float Dis = Global.Grid.transform.localPosition.x - Pos.x;
            Debug.Log(Dis);
            //判断当是第一个或者是最后一个ui的时候
            if (Global.Grid_CurrentIndex == Global.Grid_Count - 1 || Global.Grid_CurrentIndex == 0)
            {
                MoveInmarginal(Global.Grid_CurrentIndex);
            }
            if (Global.Grid_CurrentIndex < Global.Grid_Count - 1 && IsLeft)
            {
                //if (drag.x > Dis)
                if (Dis < -Screen.width / 2)
                {
                    Global.Grid_CurrentIndex++;
                    //Global.Grid.transform.localPosition = new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0);
                    //IsFinalPos = true;
                    Global.e_State = StateUI.State_Move;
                }

            }

            if (Global.Grid_CurrentIndex > 0 && IsRight)
            {
                if (Dis > Screen.width / 2)
                {
                    Global.Grid_CurrentIndex--;
                    // Global.Grid.transform.localPosition = new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0);
                    //IsFinalPos = true;
                    Global.e_State = StateUI.State_Move;
                }
            }
            MoveInmarginal(Global.Grid_CurrentIndex);
            IsDrag = false;
            IsRight = false;
            IsLeft = false;
            IsTouch = false;
            IsClick = true;
        }
    }
    #endregion

    #endregion

    protected override void Update()
    {
        base.Update();
    }
}
