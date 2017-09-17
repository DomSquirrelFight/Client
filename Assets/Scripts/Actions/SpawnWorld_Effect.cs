using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
    public class SpawnWorld_Effect : SpawnAction
    {

        public override void TrigAction()
        {

            //实例化特效
            GameObject effect = InstantiateMyEffect();
            GameObject socket = null;
            //找到sourceowner
            if (SocketName == "")
            {

                if (DataStore.SourceOwner)
                {
                    socket = DataStore.SourceOwner;
                }
                else
                {
                    socket = transform.gameObject;
                }
            }
            else
            {
                socket = GlobalHelper.FindGameObjectWithName(DataStore.SourceOwner, SocketName);
            }

            if (null != socket)
            {
                Transform tmp = socket.transform;
                effect.transform.parent = null;
                effect.transform.position = RelativePos;
                effect.transform.localRotation = Quaternion.Euler(RelativeRot);
            }
            else
            {
                Debug.LogErrorFormat("Fail to find socket{0} in SourceOwner {1}", SocketName, DataStore.SourceOwner);
            }
        }
    }
}