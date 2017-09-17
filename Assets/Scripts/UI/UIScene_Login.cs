using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Helper;
public class UIScene_Login : UIScene {

    #region 共有的成员变量
    //公有GameObject
    public GameObject m_Longin;
    public GameObject m_Register;
    public GameObject m_BackPwd;
    #endregion

    #region 系统接口
    void Start()
    {
        UIEventListener.Get(m_Longin).onClick = Login;
        UIEventListener.Get(m_Register).onClick = Register;
        UIEventListener.Get(m_BackPwd).onClick = BackPwd;
        eState = LoadingState.e_LoadSelect;
        //eScene = SceneType.SelecteLoading;
    }
    #endregion

    #region 登陆按钮事件
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
        //如果数据库信息和输入的信息相符，进入loading场景
        GlobalHelper.LoadLevel("Loading");
        //如果数据库信息和输入的信息不一致，弹出用户名和密码不一致的ui界面
        //Helpers.UIScene<UIScene_WrongPwd>();
    }
    #endregion
    #endregion

    #region 注册按钮事件
    void Register(GameObject obj)
    {
        //跳转到注册场景
        //GlobalHelper.LoadLevel("Register");
        //GlobalHelper.LoadLevel("Register");
        //弹出注册的场景的ui
        Helpers.UIScene<UIScene_Register>();
    }
    #endregion

    #region 找回密码按钮事件
    void BackPwd(GameObject obj)
    {
        //跳转到找回密码场景
        //GlobalHelper.LoadLevel("BackPwd");
        //弹出找回密码的ui
        Helpers.UIScene<UIScene_BackPwd>();
    }
    #endregion

}
