using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class GlobalHelper
{

    #region 常量表
    public static float SMoveSpeed = 4f;
    public static float SUpSpeed = 5f;

    public static float SRotSpeed = 60f;
    public static float SBoxSize = 0.6f;
    public static float SBrickDis = 0.4f;
    #endregion

    public static Vector2 GetCamArea(Vector3 middle)
    {
        Vector2 area = new Vector2();

        float halfFOV = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;
        float aspect = Camera.main.aspect;
        float distance = middle.z - Camera.main.transform.position.z;
        area.y = distance * Mathf.Tan(halfFOV);
        area.x = area.y * aspect;
     
        return area;

    }

    //确定相机的四个边界
    public static CamBorderPosition GetCamBorder(Vector3 middle)
    {
        CamBorderPosition camPos = new CamBorderPosition();

        Vector2 area = GetCamArea(middle);

        camPos.LeftBorderPos = middle - new Vector3(area.x, 0f, 0f);
        camPos.RightBorderPos = middle + new Vector3(area.x, 0f, 0f);
        camPos.TopBorderPos = middle + new Vector3(0f, area.y, 0f);
        camPos.BottomBorderPos = middle - new Vector3(0f, area.y, 0f);
        return camPos;
    }


    public static  Transform GetValues(RaycastHit hit)
    {
        return hit.transform;
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
