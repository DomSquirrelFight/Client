using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_WrongPwd : MonoBehaviour {
    public GameObject m_oBtn;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_oBtn).onClick = ClickOK;
	}
	void ClickOK(GameObject obj)
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
