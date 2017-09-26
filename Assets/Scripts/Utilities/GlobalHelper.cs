using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class GlobalHelper
{

    private static bool IsTest;
    public static void SetTest(bool istest)
    {
        IsTest = istest;
    }
    public static bool BIsTest
    {
        get
        {
            return IsTest;
        }
    }

    public static bool CheckMoveBoundaryBlock(Vector3 pos,float size)
    {

        CameraController cc = Camera.main.GetComponent<CameraController>();

        if (null != cc)
        {
            if (
                    (pos.x <= cc.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Left].x - size) ||
                    (pos.x >= cc.m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Right].x + size)
                )
                return true;//block left, right
        }
        else
            return false;


        return false;
    }

    #region 场景加载
    public static void LoadLevel(string name)
    {
        Debug.Log(name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public static AsyncOperation LoadLevelAsync(string name)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
    }
    #endregion

    //获取父亲层对象，判定是否是角色
    public static BaseActor GetBaseActorOnChild(Transform t)
    {
        return null;
    }


    public static GameObject FindGameObjectWithName(GameObject obj, string name)
    {

        if (null == obj)
            return null;

        GameObject target = null;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == name)
                return obj.transform.GetChild(i).gameObject;
            else
            {
                target = FindGameObjectWithName(obj.transform.GetChild(i).gameObject, name);
                if (null != target)
                    return target;
            }
        }

        return target;
    }

}
