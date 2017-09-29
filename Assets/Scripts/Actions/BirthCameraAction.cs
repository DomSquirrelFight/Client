using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

namespace Assets.Scripts.Action
{
    public class BirthCameraAction : BaseAction
    {

        public Transform BirthPoint;

        public Transform EndPoint;

        public float Speed;

        public eCameStates NextCamState;

        public CameraController control;

        public float duration;

        public override void TrigAction()
        {
            transform.position = BirthPoint.position;
            transform.rotation = BirthPoint.rotation;
           

        }

        protected override void Update()
        {

            if (m_bSend)
            {
                if (duration <= 0f)
                {
                    control.CamState = NextCamState;
                    SelfDestroy();
                    return;
                }

                duration -= Time.deltaTime;

                transform.position = Vector3.Lerp(transform.position, EndPoint.position, Speed * Time.deltaTime);

                transform.rotation = Quaternion.Lerp(transform.rotation, EndPoint.rotation, Speed * Time.deltaTime);
            }

            base.Update();
        }


        public override void OnStart()
        {
            base.OnStart();
        }

        void SelfDestroy()
        {
            Destroy(BirthPoint.gameObject);
            Destroy(EndPoint.gameObject);
            Destroy(this);
        }


        public void OnDrawGizmos()
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(BirthPoint.position, 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(EndPoint.position, 0.5f);

        }

       
    }

}
