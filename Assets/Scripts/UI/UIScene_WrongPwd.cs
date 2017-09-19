using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_WrongPwd : UIScene {
    public GameObject m_oBtn;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_oBtn).onClick = ClickBtn;
	}
    protected override void ClickBtn(GameObject obj)
    {
        base.ClickBtn(obj);
    }

}
