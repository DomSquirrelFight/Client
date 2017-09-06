using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //存储delta
    Vector3 drag;
    //记录grid的原始位置
    Vector3 Pos;
    //drag开始首先确定当前的card的index
    void Start()
    {
        IsFinalPos = false;
    }
    //drag 的时候，让card跟随delta移动

    #region 通过判断drag来改变ui的位置
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
            //判断当是第一个或者是最后一个ui的时候
            if (Global.Grid_CurrentIndex == Global.Grid_Count-1 || Global.Grid_CurrentIndex == 0)
            {
                MoveInmarginal(Global.Grid_CurrentIndex);
            }
            if (Global.Grid_CurrentIndex < Global.Grid_Count -1&& IsLeft)
            {
                if (drag.x > Dis)
                {
                    Global.Grid_CurrentIndex++;
                    //Global.Grid.transform.localPosition = new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0);
                    IsFinalPos = true;
                }

            }

            if (Global.Grid_CurrentIndex > 0 && IsRight)
            {
                if (drag.x < Dis)
                {
                    Global.Grid_CurrentIndex--;
                    // Global.Grid.transform.localPosition = new Vector3(-(Global.Grid_CurrentIndex * Global.Grid_PerSize), 0, 0);
                    IsFinalPos = true;
                }
            }
            IsDrag = false;
            IsRight = false;
            IsLeft = false;
            IsTouch = false;
            IsClick = true;
        }


    }

    #endregion

    // Update is called once per frame
    void Update () {
        //通过判断drag来改变ui的位置
        if (IsFinalPos)
        {
            //drag结束之后移动btn和ui的位置
            MoveOutDrag(Global.Grid_CurrentIndex);
        }
        if ((Mathf.Abs(Global.Grid.transform.localPosition.x + (Global.Grid_CurrentIndex * Global.Grid_PerSize)) )< 0.5f)
        {
            IsFinalPos = false;
        }

    }
}
