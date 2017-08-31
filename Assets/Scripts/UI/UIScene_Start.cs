using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_Start : MonoBehaviour {
    public GameObject m_btn;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_btn).onClick = PressBtn;
	}
	void PressBtn(GameObject obj)
    {
        //切换场景到登录场景
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }
}
