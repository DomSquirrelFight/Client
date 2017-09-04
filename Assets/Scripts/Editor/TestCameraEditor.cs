using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DT.Assets.CameraController;
using System.Linq;
using DT.Assets.CameraController.AttTypeDefine;
[CustomEditor(typeof(TestCamera))]
public class TestCameraEditor : Editor {

    TestCamera tc;

    void OnEnable()
    {
        tc = target as TestCamera;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }




    void OnSceneGUI()
    {
        
        if (tc.m_tTarget)
        {

            //绘制目标平面

            //显示四个交点<相机边界射线和目标平面>
            Handles.color = Handles.xAxisColor;
            for (int i = 0; i < 4; i++)
            {
                Handles.SphereHandleCap(
                                                           0,
                                                           tc.m_vPoints[i],
                                                           Quaternion.identity,
                                                           1f,
                                                           EventType.Repaint
               );
            }

            //绘制四个交点组成的平面
            Handles.color = Color.white;
            Color faceColor = new Color(1f, 1f, 1f, 0.2f);
            Color outlineColor = new Color(1f, 1f, 1f, 0.2f);

            Vector3[] tmp = new Vector3[] { tc.m_vPoints[2], tc.m_vPoints[3], tc.m_vPoints[1], tc.m_vPoints[0] };
            Handles.DrawSolidRectangleWithOutline(tmp, faceColor, outlineColor);




            //给目标位置绘制一个大的框架球体，当点中，那么绘制当前球体视野视野边界的四个顶点<上下左右>
            Handles.DrawWireCube(tc.m_tTarget.position, new Vector3 (1.5f, 1.5f, 1.5f));

        }

    }

}


//if (Handles.Button(tc.m_vPoints[i], Quaternion.identity, 0.5f, 1f, Handles.DotHandleCap))
//{

//}
//Vector3[] values = Enumerable.Select(from i in tc.m_dCamDir select i,
//       value => GetValues(value)).ToArray();

//private Vector3 GetValues(KeyValuePair<eCamFourCorner, Vector3> i)
//{
//    return i.Value;
//} 