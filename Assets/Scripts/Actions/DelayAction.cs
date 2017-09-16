using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Action
{

    public abstract class DelayAction : MonoBehaviour
    {


        public float m_fDelayTime;

        float m_fStartTime = 0f;

        protected bool m_bSend = false;

        public virtual void Awake()
        {
            m_fStartTime = Time.time;
        }

        public virtual void Update()
        {
            if (m_bSend)
                return;

            if (Time.time - m_fStartTime > m_fDelayTime)
            {
                TrigAction();
                m_bSend = true;
            }

        }

        public virtual void TrigAction() { }                              //触发行为

    }

}
