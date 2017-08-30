using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JumpDataStore))]
public class JumpDataStoreEditor : Editor {

    JumpDataStore JumpData;
    private void OnEnable()
    {
        JumpData = target as JumpDataStore;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        #region 显示 Big Jump Percent
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Big Jump Percent");
        float BigJumpPercent = EditorGUILayout.Slider(JumpData.m_fChangeBigJumpPercent,0f, 0.45f);
        if (BigJumpPercent != JumpData.m_fChangeBigJumpPercent)
        {
            Undo.RecordObject(JumpData, "Revert Change Big Jump Percent");

            JumpData.m_fChangeBigJumpPercent = BigJumpPercent;

            ////清空曲线数据
            //while (JumpData.m_acBigJump.length > 0)
            //{
            //    JumpData.m_acBigJump.RemoveKey(0);
            //}

            ////添加起点，中点和终点
            //JumpData.m_acBigJump.AddKey(new Keyframe(0, JumpData.m_acSmallJump.Evaluate(BigJumpPercent)));
            //JumpData.m_acBigJump.AddKey(new Keyframe(0.5f, 1f));
            //JumpData.m_acBigJump.AddKey(new Keyframe(1f, 0f));


          
            EditorUtility.SetDirty(JumpData);
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space();

        #region 提示框

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.HelpBox("Don't Edit AcBig Jump's First KeyFrame Value which is calculated by program", MessageType.Warning, true);

        EditorGUILayout.EndHorizontal();

        #endregion



    }

}
