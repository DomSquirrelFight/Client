using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_ResetPwd : UIScene {
    public GameObject m_Login;
	// Use this for initialization
	void Start () {
        eState = LoadingState.e_LoadSelect;
        eScene = SceneType.SelecteLoading;
        UIEventListener.Get(m_Login).onClick = Loading;
	}
	//登录成功，切换到selected loading
    void Loading(GameObject obj)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
