using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action {

    public class SpawnOwner_Effect : SpawnAction {

        public override void TrigAction()               
        {
            
            //实例化特效
            GameObject effect = InstantiateMyEffect();
            GameObject socket = null;
            //找到sourceowner
            if (SocketName == "" ) {

                if (DataStore.SourceOwner)
                {
                    socket = DataStore.SourceOwner;
                }
            }
            else
            {
                socket = GlobalHelper.FindGameObjectWithName(DataStore.SourceOwner, SocketName);
            }

            if (null != socket)
            {
                effect.transform.parent = socket.transform;
                effect.transform.localPosition = RelativePos;
                effect.transform.localRotation = Quaternion.Euler(RelativeRot);
            }
            else
            {
                effect.transform.parent = null;
                effect.transform.Rotate(RelativeRot, Space.Self);
                effect.transform.Translate(RelativePos, Space.Self);
            }
        }

    }

}

