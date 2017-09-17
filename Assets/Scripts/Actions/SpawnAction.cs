using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class SpawnAction : BaseAction
    {
        public GameObject SpawnObj;

        public string SocketName;

        public Vector3 RelativePos;

        public Vector3 RelativeRot;

        protected GameObject InstantiateMyEffect()
        {
            if (null == SpawnObj)
            {
                Debug.LogErrorFormat("Skill Name: {0}, Fail to find Effect Prefab", transform.parent.name);
                return null;
            }
            GameObject obj = Instantiate<GameObject>(SpawnObj);
            return obj;
        }


    }
}

