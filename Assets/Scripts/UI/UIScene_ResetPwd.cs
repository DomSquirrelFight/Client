using UnityEngine;
using AttTypeDefine;

public class UIScene_ResetPwd : UIScene {

    #region 成员变量
    //button
    public GameObject m_Login;
    public GameObject m_oExit;
    //label
    public UILabel m_password;
    public UILabel m_confirmpassword;
    #endregion

    #region 系统接口.
    void Start()
    {
        eState = LoadingState.e_LoadSelect;
        eScene = SceneType.SelecteLoading;
        UIEventListener.Get(m_Login).onClick = Loading;
        UIEventListener.Get(m_oExit).onClick = Exit;
    }
    #endregion

    #region 登陆按钮
    //登录成功，切换到selected loading
    void Loading(GameObject obj)
    {
        GlobalHelper.LoadLevel("Loading");
    }
    #endregion

    #region 退出按钮
    void Exit(GameObject obj)
    {
        Destroy(gameObject);
    }
    #endregion




}
