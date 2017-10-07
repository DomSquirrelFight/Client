using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Action;

public class ChangeAlpah : BaseAction {
     SpriteRenderer m_sRender;
    public float m_fSpeed;
    Color tmp;
    public  float m_fMax;
    public float m_fMin;
    public override void TrigAction()
    {
        m_sRender = gameObject.GetComponent<SpriteRenderer>();
         tmp = m_sRender.color;
        base.TrigAction();
    }
    protected override void Update()
    {
        base.Update();
        if (null == m_sRender)
            return;
        ChangeAlpha();
        m_sRender.color = tmp;
    }

    void ChangeAlpha()
    {
        if (tmp.a >= m_fMax)
            tmp.a = m_fMax;
        else if (tmp.a <= m_fMin)
            tmp.a = m_fMin;
        tmp.a -= m_fSpeed * Time.deltaTime;
    }
}
