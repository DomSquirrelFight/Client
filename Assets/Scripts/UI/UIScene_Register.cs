using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_Register : MonoBehaviour {
    public GameObject m_GetNum;
    void Start()
    {
        UIEventListener.Get(m_GetNum).onClick = GetNum;
    }
    void GetNum(GameObject obj)
    {
        bool IsGet = false;
        if(!IsGet)
        {
            //判断所有input的值不为空，并且手机验证码和数据库中的数据相符
            //跳转到申请成功的界面
            UnityEngine.SceneManagement.SceneManager.LoadScene("GetNum");
        }

    }
}
