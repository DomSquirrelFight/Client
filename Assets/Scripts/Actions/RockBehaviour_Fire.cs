using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
    public class RockBehaviour_Fire : SpawnAction
    {
        public float FSpeed;
        
        public float FDuration;

        float fstartTime = 0f;

        public override void TrigAction()
        {
            fstartTime = Time.time;
        }

        public override void Update()
        {

            if (m_bSend)
            {
                if (Time.time - fstartTime > FDuration)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.Translate(transform.forward * FSpeed * Time.deltaTime, Space.World);
                }
            }

            base.Update();
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(gameObject);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("NPC"))
            {
                Debug.Log("hit somebody : name ->" + other.gameObject.name);
            }
        }

    }
}

