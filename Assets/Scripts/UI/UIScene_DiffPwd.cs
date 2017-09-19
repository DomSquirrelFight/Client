using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_DiffPwd : UIScene {
    public GameObject m_oOkBtn;

	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_oOkBtn).onClick = ClickBtn;
	}

    protected override void ClickBtn(GameObject obj)
    {
        base.ClickBtn(obj);
    }
}
