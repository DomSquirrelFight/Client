﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_Login : UIScene {
    //公有GameObject
    public  GameObject m_Longin;
    public GameObject m_Register;
    public GameObject m_BackPwd;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_Longin).onClick = Login;
        UIEventListener.Get(m_Register).onClick = Register;
        UIEventListener.Get(m_BackPwd).onClick = BackPwd;
        eState = LoadingState.e_LoadSelect;
        eScene = SceneType.SelecteLoading;
	}
    void Login(GameObject obj)
    {
        //判断数据库中input的账号和密码相符，进行场景切换到loading界面
        ServerLogin("");
    }
    #region 服务器接口
    //请求登陆
    void RequestLogin()
    {

    }
    //接受服务器的返回数据
    void ServerLogin(string data)
    {
        GlobalHelper.LoadLevel("Loading");

    }
    #endregion



    void Register(GameObject obj)
    {
        //跳转到注册场景
        //GlobalHelper.LoadLevel("Register");
        GlobalHelper.LoadLevel("Register");
    }
    void BackPwd(GameObject obj)
    {
        //跳转到找回密码场景
        GlobalHelper.LoadLevel("BackPwd");
    }
	

}
