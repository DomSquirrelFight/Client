using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class BaseAttr : MonoBehaviour
{

    #region 角色阵营
    eCharacSide characSide;
    public eCharacSide CharacSide
    {
        get
        {
            return characSide;
        }
    }
    #endregion

    #region 角色类型
    eCharacType charactype;
    public eCharacType CharacType
    {
        get
        {
            return charactype;
        }
    }
    #endregion

    public void InitAttr(eCharacSide side, eCharacType type)
    {
        charactype = type;
        characSide = side;
    }

}
