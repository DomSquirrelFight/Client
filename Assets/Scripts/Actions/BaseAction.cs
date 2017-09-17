using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{

    public abstract class BaseAction : MonoBehaviour
    {

        public float m_fDelayTime;
        public eCoutTimeType CountTimeType = eCoutTimeType.CountType_Auto;

        float m_fStartTime = 0f;
        float m_fConStartTime = 0f;
        protected bool m_bSend = false;

        public virtual void Awake()
        {
            if (CountTimeType == eCoutTimeType.CountType_Auto)
                m_fStartTime = Time.time;
        }

        public void OnStart()
        {
            if (CountTimeType == eCoutTimeType.CountType_Condition)
                m_fConStartTime = Time.time;
        }

        public virtual void Update()
        {
            if (m_bSend)
                return;
            if (CountTimeType == eCoutTimeType.CountType_Auto && 0f != m_fStartTime)
            {
                if (Time.time - m_fStartTime > m_fDelayTime)
                {
                    TrigAction();
                    m_bSend = true;
                }
            }
            else if (CountTimeType == eCoutTimeType.CountType_Condition && 0f != m_fConStartTime)
            {
                if (Time.time - m_fConStartTime > m_fDelayTime)
                {
                    TrigAction();
                    m_bSend = true;
                }
            }

        }

        public virtual void TrigAction() { }                              //触发行为

        private ActionDataStore datastore;
        public ActionDataStore DataStore
        {
            get
            {
                if (null == datastore)
                    datastore = gameObject.GetComponent<ActionDataStore>();
                return datastore;
            }
        }

    }

}
