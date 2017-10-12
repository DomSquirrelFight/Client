using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[CustomEditor(typeof(DesignBezierPath))]
public class DesignBezierPathEditor : Editor {

    #region 成员变量
    int m_nSelectedIndex = -1;
    DesignBezierPath curve;

    #endregion

    #region 系统接口
    public void OnSceneGUI()
    {
        curve = target as DesignBezierPath;
        Vector3 p0 = ShowPoint(0);

        for (int i = 1; i < curve.PointNum; i += 3)
        {
            Vector3 p1 = ShowPoint(i);
            Vector3 p2 = ShowPoint(i + 1);
            Vector3 p3 = ShowPoint(i + 2);

            Handles.color = Color.red;
            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p2, p3);

            Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
            p0 = p3;
        }
    }
    public override void OnInspectorGUI()
    {
        curve = target as DesignBezierPath;
        if (m_nSelectedIndex != -1)
        {
            DrawSelectedIndexPoint();
        }

        if (GUILayout.Button("Add Curve"))
        {
            Undo.RecordObject(curve, "Add Curve");
            curve.AddCurve();
            EditorUtility.SetDirty(curve);
        }
    }
    #endregion

    Vector3 ShowPoint(int index)
    {

        //获得curve中的点坐标
        Vector3 p = curve.transform.TransformPoint(curve[index]);
        EditorGUI.BeginChangeCheck();
        if (Handles.Button(p, curve.transform.rotation, 0.08f, 0.16f, Handles.DotHandleCap))
        {
            m_nSelectedIndex = index;
            Repaint();
        }
        if (index == m_nSelectedIndex)
        {
            p = Handles.DoPositionHandle(p, curve.transform.rotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(curve, "Move Point");
                curve[index] = curve.transform.InverseTransformPoint(p);
                EditorUtility.SetDirty(curve);
            }
        }
        return p;
    }

    void DrawSelectedIndexPoint()
    {
        GUILayout.Label("Selected Point");
        EditorGUI.BeginChangeCheck();
        Vector3 select = curve.transform.TransformPoint(curve[m_nSelectedIndex]);
        Vector3 p = EditorGUILayout.Vector3Field("point position", select);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Change Point");
            curve[m_nSelectedIndex] = p;
            EditorUtility.SetDirty(curve);
        }

        EditorGUI.BeginChangeCheck();
        eBezierLineConstrainedMode mode = (eBezierLineConstrainedMode)EditorGUILayout.EnumPopup(curve.GetModeByPointIndex(m_nSelectedIndex));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Change Mode");
            curve.SetBezierLineConstrainedMode(m_nSelectedIndex, mode);
            EditorUtility.SetDirty(curve);
        }
    }

}
