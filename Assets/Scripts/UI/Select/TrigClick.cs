using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class TrigClick : MakeMove {
    //主要是为了告诉监听事件是触发了哪个按钮
    IniteBtn ib;
    private void Start()
    {
         ib= gameObject.transform.parent.GetComponent<IniteBtn>();
        //Destroy(gameObject.GetComponent<TweenScale>());
    }
    int ClickIndex;
    public void OnStart(int index)
    {

        UIEventListener.Get(gameObject).onClick = ClickBtn;
        
        ClickIndex = index;
        
    }
    void ClickBtn(GameObject obj)
    {
        ib.ClickBtn(ClickIndex);
    }
}
