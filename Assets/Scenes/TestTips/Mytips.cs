using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mytips : MonoBehaviour {
    //list数组 为string类型，可以在inspector中输入想要输入的文字
    public List<string> m_lTips;
    //存放label，用来显示文字
    public UILabel MyTip;
    bool m_bIsChangindex = false;
    int m_CurIndex;
    private void Update()
    {
        if (!m_bIsChangindex)
        {
            Invoke("RandomIndex", 3f);
            MyTip.text = m_lTips[m_CurIndex];
            m_bIsChangindex = true;
        }

    }
    void RandomIndex()
    {
        int i = Random.Range(0, m_lTips.Count);
        m_CurIndex = i;
        m_bIsChangindex = false;
    }




}
