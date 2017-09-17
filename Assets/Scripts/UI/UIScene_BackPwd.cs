using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_BackPwd : MonoBehaviour {

    #region 成员变量
    public GameObject m_BackPwd;
    public GameObject m_Back;
    #endregion

    #region 系统接口
    void Start()
    {
        //找回密码 按钮
        UIEventListener.Get(m_BackPwd).onClick = BackPwd;
        //返回按钮
        UIEventListener.Get(m_Back).onClick = Back;
        UIPanel up = gameObject.GetComponent<UIPanel>();
        up.depth = 2;
    }
    #endregion

    #region 找回密码按钮事件
    void BackPwd(GameObject obj)
    {
        ServerBackPwd("");

    }
    #region 服务器接口
    //请求登陆
    void RequestBackPwd()
    {

    }
    //接受服务器的返回数据
    void ServerBackPwd(string data)
    {
        //如果数据库信息和输入的信息相符，进入loading场景，进入select界面
        GlobalHelper.LoadLevel("Loading");
        //如果数据库信息和输入的信息不一致，弹出用户名和密码不一致的ui界面
        //Helpers.UIScene<UIScene_WrongPwd>();
    }
    #endregion
    #endregion

    #region 返回按钮事件
    void Back(GameObject obj)
    {
        //返回到登录场景
        //GlobalHelper.LoadLevel("Login");
        Destroy(gameObject);
    }
    #endregion



    // Update is called once per frame
    void Update () {
		
	}
}
