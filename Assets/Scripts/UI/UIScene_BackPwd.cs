using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_BackPwd : MonoBehaviour {
    public GameObject m_BackPwd;
    public GameObject m_Back;
	// Use this for initialization
	void Start () {
        //找回密码 按钮
        UIEventListener.Get(m_BackPwd).onClick = BackPwd;
        //返回按钮
        UIEventListener.Get(m_Back).onClick = Back;
	}
	void BackPwd(GameObject obj)
    {
        bool IsRight = false;
        //判断当前账号和手机号是否匹配，如果匹配，在判断手机验证码是否匹配，如果匹配就返回true
        IsRight = true;
        //如果返回true，跳转到重置密码界面
        if(IsRight)
        {
            GlobalHelper.LoadLevel("NewPwd");
        }
        else
        {
            //弹出ui，信息不符
        }

    }
    void Back(GameObject obj)
    {
        //返回到登录场景
        GlobalHelper.LoadLevel("Login");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
