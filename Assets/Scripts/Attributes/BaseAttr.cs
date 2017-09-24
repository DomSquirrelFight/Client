using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.AssetInfoEditor;
public class BaseAttr : MonoBehaviour
{

    private RoleInfos roleinfos;
    public RoleInfos RoleInfo {
        get {
            return roleinfos;
        }
    }


    public void InitAttr(RoleInfos _infos)
    {
        roleinfos = _infos;
    }

}
