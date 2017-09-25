using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Helper;

public class UIScene_Main : UIScene {


    #region 共有的成员变量
    //公有GameObject
    public GameObject m_Longin;
    public GameObject m_oExit;
    #endregion

    #region 系统接口
    void Start()
    {
        UIEventListener.Get(m_Longin).onClick = Login;
        UIEventListener.Get(m_oExit).onClick = ExitBtn;

        //eScene = SceneType.SelecteLoading;
    }
    #endregion

    #region 登陆按钮跳转
    void Login(GameObject obj)
    {
        Helpers.UIScene<UIScene_Login>();
    }
#endregion

    #region 退出按钮事件
    void ExitBtn(GameObject obj)
    {
        Application.Quit();
        Debug.Log("Exit the game");
    }
    #endregion
}
