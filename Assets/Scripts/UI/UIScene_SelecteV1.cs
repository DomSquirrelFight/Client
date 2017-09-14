using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_SelecteV1 : UIScene {
    public GameObject m_oOk;
    public GameObject m_oBack;
	// Use this for initialization
	void Start () {
        eState = LoadingState.e_LoadLevel;
        UIEventListener.Get(m_oOk).onClick = PressOK;
        UIEventListener.Get(m_oBack).onClick = PressBack;
	}
	void PressOK(GameObject obj)
    {
        eState = LoadingState.e_LoadLevel;
        GlobalHelper.LoadLevel("Loading");
    }
    void PressBack(GameObject obj)
    {
        GlobalHelper.LoadLevel("Login");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
