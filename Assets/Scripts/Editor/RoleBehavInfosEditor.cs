using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AttTypeDefine;
namespace Assets.Scripts.AssetInfoEditor
{
    public class RoleBehavInfosEditor : EditorWindow
    {

        #region 变量
        public RoleBehavInfos _data;

        [MenuItem("Window/Setting_RoleBehavInfos")]
        public static void ShowWindow()
        {
            GetWindow(typeof(RoleBehavInfosEditor), true, "Setting_RoleBehavInfos");
        }

        string datapath = "Assets/Resources/Assets/RoleBehavInfos/";
        string path;
        string DataPath                                                     //Asset文件保存路径
        {
            get
            {
                return datapath + "tmp.asset";// +"Setting_AssetEditor" + ".asset";
            }
        }

        int nRoleId = 0;

        int nValue = 0;                                                      //用来保存枚举变量的整形数据

        float fValue = 0f;                                                  //用来保存浮点数据

        bool bValue = false;


        string[] arrRunMode = new string[] { "横向运动", "纵向运动" };
        int[] arrNRunMode = new int[] { 0, 1};
        #endregion

        void OnGUI()
        {

            #region 初始化数据
            if (null == _data)
            {
                _data = AssetDatabase.LoadAssetAtPath(DataPath, typeof(RoleBehavInfos)) as RoleBehavInfos;
                if (null == _data)
                {
                    _data = CreateInstance<RoleBehavInfos>() as RoleBehavInfos;
                    AssetDatabase.CreateAsset(_data, DataPath);
                    AssetDatabase.Refresh();
                }
            }
            #endregion

            #region Role ID
            EditorGUILayout.BeginHorizontal();
            nValue = EditorGUILayout.IntField("角色ID", _data.RoleID);
            if (nValue != _data.RoleID)
            {
                _data.RoleID = nValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 运动模式
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("运动模式");
            nValue = EditorGUILayout.IntPopup((int)_data.RunMode, arrRunMode, arrNRunMode);

            if (nValue != (int)_data.RunMode)
            {
                _data.RunMode = (eRunMode)nValue;
            }
            EditorGUILayout.EndHorizontal();

            #endregion

            #region 是否可以小跳跃
            EditorGUILayout.BeginHorizontal();
            bValue = EditorGUILayout.Toggle("是否可以小跳跃", _data.CanSmallJump);
            if (bValue != _data.CanSmallJump)
            {
                _data.CanSmallJump = bValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 小跳跃加速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("小跳跃加速度");
            fValue = EditorGUILayout.FloatField(_data.SmallJumpAccel);
            if (fValue != _data.SmallJumpAccel)
            {
                _data.SmallJumpAccel = fValue;
                _data.SmallJumpInitSpeed = GlobalHelper.CalculateInitSpeed(_data.SmallJumpAccel, _data.SmallJumpUpDuration);
                _data.SmallJumpHeight = GlobalHelper.CalculateJumpHeight(_data.SmallJumpInitSpeed, _data.SmallJumpAccel, _data.SmallJumpUpDuration);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 小跳跃上升时间
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("小跳跃上升时间");
            fValue = EditorGUILayout.FloatField(_data.SmallJumpUpDuration);
            if (fValue != _data.SmallJumpUpDuration)
            {
                _data.SmallJumpUpDuration = fValue;
                _data.SmallJumpInitSpeed = GlobalHelper.CalculateInitSpeed(_data.SmallJumpAccel, _data.SmallJumpUpDuration);
                _data.SmallJumpHeight = GlobalHelper.CalculateJumpHeight(_data.SmallJumpInitSpeed, _data.SmallJumpAccel, _data.SmallJumpUpDuration);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 小跳跃初速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("小跳跃初速度");
            EditorGUILayout.LabelField(_data.SmallJumpInitSpeed.ToString());
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 小跳跃高度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("小跳跃高度");
            EditorGUILayout.LabelField(_data.SmallJumpHeight.ToString());
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 是否可以大跳跃
            EditorGUILayout.BeginHorizontal();
            bValue = EditorGUILayout.Toggle("是否可以大跳跃", _data.CanBigJump);
            if (bValue != _data.CanBigJump)
            {
                _data.CanBigJump = bValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 大跳跃加速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("大跳跃加速度");
            fValue = EditorGUILayout.FloatField(_data.BigJumpAccel);
            if (fValue != _data.BigJumpAccel)
            {
                _data.BigJumpAccel = fValue;
                _data.BigJumpInitSpeed = GlobalHelper.CalculateInitSpeed(_data.BigJumpAccel, _data.BigJumpUpDuration);
                _data.BigJumpHeight = GlobalHelper.CalculateJumpHeight(_data.BigJumpInitSpeed, _data.BigJumpAccel, _data.BigJumpUpDuration);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 大跳跃上升时间
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("大跳跃上升时间");
            fValue = EditorGUILayout.FloatField(_data.BigJumpUpDuration);
            if (fValue != _data.BigJumpUpDuration)
            {
                _data.BigJumpUpDuration = fValue;
                _data.BigJumpInitSpeed = GlobalHelper.CalculateInitSpeed(_data.BigJumpAccel, _data.BigJumpUpDuration);
                _data.BigJumpHeight = GlobalHelper.CalculateJumpHeight(_data.BigJumpInitSpeed, _data.BigJumpAccel, _data.BigJumpUpDuration);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 大跳跃初速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("大跳跃初速度");
            EditorGUILayout.LabelField(_data.BigJumpInitSpeed.ToString());
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 大跳跃高度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("大跳跃高度");
            EditorGUILayout.LabelField(_data.BigJumpHeight.ToString());
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 是否可以发射子弹
            EditorGUILayout.BeginHorizontal();
            bValue = EditorGUILayout.Toggle("是否可以发射子弹", _data.CanFire);
            if (bValue != _data.CanFire)
            {
                _data.CanFire = bValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 是否可以举箱子
            EditorGUILayout.BeginHorizontal();
            bValue = EditorGUILayout.Toggle("是否可以举箱子", _data.CanPickUpBox);
            if (bValue != _data.CanPickUpBox)
            {
                _data.CanPickUpBox = bValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 角色移动速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("角色移动速度");
            fValue = EditorGUILayout.FloatField(_data.RoleMoveSpeed);
            if (fValue != _data.RoleMoveSpeed)
            {
                _data.RoleMoveSpeed = fValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 角色后退速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("角色后退速度");
            fValue = EditorGUILayout.FloatField(_data.RoleInjureBackSpeed);
            if (fValue != _data.RoleInjureBackSpeed)
            {
                _data.RoleInjureBackSpeed = fValue;
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 提交数据
            GUI.color = Color.green;
            if (GUILayout.Button("提交数据", GUILayout.Width(80)))
            {
                //AssetDatabase.CreateAsset(_data, path);
                //AssetDatabase.Refresh();
                //
                ////数据提交
                ScriptableObject scriptable = AssetDatabase.LoadAssetAtPath(DataPath, typeof(ScriptableObject)) as ScriptableObject;
                //scriptable.name = _data.nRoleID.ToString() + ".asset";
                //_data.name = _data.nRoleID.ToString() + ".asset";
                EditorUtility.SetDirty(scriptable);
                //string newname = "RoleBehav" + _data.RoleID.ToString();// +".asset";

                //string[] b = AssetDatabase.FindAssets(newname);

                //if (null != b && b.Length > 0)
                //{
                //    AssetDatabase.RemoveAssetBundleName(b[0], true);
                //}

                AssetDatabase.RenameAsset(DataPath, "RoleBehav" + _data.RoleID.ToString() + ".asset");
                AssetDatabase.SaveAssets();
                Close();

            }
            #endregion

        }
    }
}

//#region 角色旋转速度
//EditorGUILayout.BeginHorizontal();
//EditorGUILayout.LabelField("角色旋转速度");
//fValue = EditorGUILayout.FloatField(_data.RoleRotSpeed);
//if (fValue != _data.RoleRotSpeed)
//{
//    _data.RoleRotSpeed = fValue;
//}
//EditorGUILayout.EndHorizontal();
//#endregion