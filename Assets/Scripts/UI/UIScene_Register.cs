using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Helper;

public class UIScene_Register : MonoBehaviour {
    #region 成员变量
    public GameObject m_GetNum;
    public GameObject m_oBackbtn;
    #endregion

    #region 系统接口
    void Start()
    {
        UIEventListener.Get(m_GetNum).onClick = GetNum;
        UIEventListener.Get(m_oBackbtn).onClick = GoBack;
        //初始化当前的ui界面，让当前的ui界面的深度高于登陆界面
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        panel.depth = 1;
    }
    #endregion

    #region 注册成功按钮事件
    void GetNum(GameObject obj)
    {
        ServerRegister("");

    }

    #region 服务器接口
    void RequestLogin()
    {

    }
    //接受服务器的返回数据
    void ServerRegister(string data)
    {
        //两次输入的密码一致，手机验证码正确，可以成功注册,弹出注册成功的ui
        Helpers.UIScene<UIScene_GetNum>();
        //密码不一致，弹出“密码不一致的ui界面UIScene_WrongPwd”
        //手机验证码错误，弹出“手机验证码错误的ui界面UIScene_MobileCode"

    }
    #endregion
    #endregion

    #region 返回按钮事件
    void GoBack(GameObject obj)
    {
        Destroy(gameObject);
    }
    #endregion


}
