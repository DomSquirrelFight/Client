using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_GetNum : UIScene {
    public GameObject m_Login;
	// Use this for initialization
	void Start () {
        //注册成功，点击login，登录成功，进入人物选择界面
        UIEventListener.Get(m_Login).onClick = Login;
        //当前跳转到selectedloading
        eState = LoadingState.e_LoadSelect;
        eScene = SceneType.SelecteLoading;
	}
	//跳转到人物选择界面
    void Login(GameObject obj)
    {
        //做一次判断，当前用户名和密码是不是和数据库相符
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
