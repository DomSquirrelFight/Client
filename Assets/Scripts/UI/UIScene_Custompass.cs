using UnityEngine;
using AttTypeDefine;

public class UIScene_Custompass : UIScene {

    #region 成员变量
    public GameObject[] m_oPass;
    public GameObject m_oSelect;
  
    #endregion

    #region 系统接口
    private void Start()
    {
        Global.dragstate = DragState.State_Drag;
        InitePass();
    }
    private void Update()
    {
        
    }
    #endregion

    #region 初始化关卡
    void InitePass()
    {
        for(int i=0;i< m_oPass.Length;i++)
        {
             PassBehavior pb= m_oPass[i].AddComponent<PassBehavior>();
            pb.OnStart(i, m_oSelect);
        }
    }
#endregion
}
