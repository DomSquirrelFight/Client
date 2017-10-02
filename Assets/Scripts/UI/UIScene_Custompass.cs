using UnityEngine;
using AttTypeDefine;

public class UIScene_Custompass : UIScene {

    #region 成员变量
    public GameObject[] m_oPass;
    public GameObject m_oSelect;
    public GameObject m_oBack;
 
    #endregion

    #region 系统接口
    private void Start()
    {
        UIEventListener.Get(m_oBack).onClick = ClickBtn;
        InitePass();
    }
    #endregion

    #region 初始化关卡
    void InitePass()
    {
        dragstate = DragState.State_Drag;
        for (int i=0;i< m_oPass.Length;i++)
        {
             PassBehavior pb= m_oPass[i].AddComponent<PassBehavior>();
            pb.OnStart(i, m_oSelect);
        }
    }
#endregion
}
