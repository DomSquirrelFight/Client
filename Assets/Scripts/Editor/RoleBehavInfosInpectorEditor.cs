﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.AssetInfoEditor;
using AttTypeDefine;
[CustomEditor(typeof(RoleBehavInfos))]
public class RoleBehavInfosInpectorEditor : Editor {


    RoleBehavInfos _data;

    int nRoleId = 0;

    int nValue = 0;                                                      //用来保存枚举变量的整形数据

    float fValue = 0f;                                                  //用来保存浮点数据

    bool bValue = false;

    string[] arrRunMode = new string[] { "横向运动", "纵向运动" };
    int[] arrNRunMode = new int[] { 0, 1 };

    string[] arrVRunState = new string[] { "横向-左", "横向-中", "横向-右"};
    int[] arrNvRunState = new int[] { 0, 1, 2 };

    void OnEnable()
    {
        _data = target as RoleBehavInfos;
    }


    void CommonMove()
    {
        #region 是否可以小跳跃
        EditorGUILayout.BeginHorizontal();
        bValue = EditorGUILayout.Toggle("是否可以小跳跃", _data.CanSmallJump);
        if (bValue != _data.CanSmallJump)
        {
            _data.CanSmallJump = bValue;
            EditorUtility.SetDirty(_data);
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
            EditorUtility.SetDirty(_data);
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
            EditorUtility.SetDirty(_data);
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

        #region 角色移动速度
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("角色移动速度");
        fValue = EditorGUILayout.FloatField(_data.RoleMoveSpeed);
        if (fValue != _data.RoleMoveSpeed)
        {
            _data.RoleMoveSpeed = fValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

    }

    void HorizontalMove()
    {
        CommonMove();

        #region 是否可以发射子弹
        EditorGUILayout.BeginHorizontal();
        bValue = EditorGUILayout.Toggle("是否可以发射子弹", _data.CanFire);
        if (bValue != _data.CanFire)
        {
            _data.CanFire = bValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region 是否可以举箱子
        EditorGUILayout.BeginHorizontal();
        bValue = EditorGUILayout.Toggle("是否可以举箱子", _data.CanPickUpBox);
        if (bValue != _data.CanPickUpBox)
        {
            _data.CanPickUpBox = bValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #region 角色后退速度
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("角色后退速度");
        fValue = EditorGUILayout.FloatField(_data.RoleInjureBackSpeed);
        if (fValue != _data.RoleInjureBackSpeed)
        {
            _data.RoleInjureBackSpeed = fValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #endregion
        #endregion
    }

    void VerticalMove()
    {
        CommonMove();

        #region 是否可以大跳跃
        EditorGUILayout.BeginHorizontal();
        bValue = EditorGUILayout.Toggle("是否可以大跳跃", _data.CanBigJump);
        if (bValue != _data.CanBigJump)
        {
            _data.CanBigJump = bValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        if (_data.CanBigJump)
        {
            #region 大跳跃加速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("大跳跃加速度");
            fValue = EditorGUILayout.FloatField(_data.BigJumpAccel);
            if (fValue != _data.BigJumpAccel)
            {
                _data.BigJumpAccel = fValue;
                _data.BigJumpInitSpeed = GlobalHelper.CalculateInitSpeed(_data.BigJumpAccel, _data.BigJumpUpDuration);
                _data.BigJumpHeight = GlobalHelper.CalculateJumpHeight(_data.BigJumpInitSpeed, _data.BigJumpAccel, _data.BigJumpUpDuration);
                EditorUtility.SetDirty(_data);
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
                EditorUtility.SetDirty(_data);
            }
            EditorGUILayout.EndHorizontal();
            #endregion
        }

        #region 是否可以横向运动
        EditorGUILayout.BeginHorizontal();
        bValue = EditorGUILayout.Toggle("是否可以横向运动", _data.CanRoleMoveHorizontal);
        if (bValue != _data.CanRoleMoveHorizontal)
        {
            _data.CanRoleMoveHorizontal = bValue;
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        if (_data.CanRoleMoveHorizontal)
        {
            #region 横向运动速度
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("横向运动速度");
            fValue = EditorGUILayout.FloatField(_data.RoleMoveHorizontalSpeed);
            if (fValue != _data.RoleMoveHorizontalSpeed)
            {
                _data.RoleMoveHorizontalSpeed = fValue;
                _data.RoleMoveHorizontalDistance = _data.RoleMoveHorizontalSpeed * _data.RoleMoveHorizontalDuration;
                EditorUtility.SetDirty(_data);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 角色横向运动持续时间
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("角色横向运动持续时间");
            fValue = EditorGUILayout.FloatField(_data.RoleMoveHorizontalDuration);
            if (fValue != _data.RoleMoveHorizontalDuration)
            {
                _data.RoleMoveHorizontalDuration = fValue;
                _data.RoleMoveHorizontalDistance = _data.RoleMoveHorizontalSpeed * _data.RoleMoveHorizontalDuration;
                EditorUtility.SetDirty(_data);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 角色横向运动距离
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("角色横向运动距离");
            _data.RoleMoveHorizontalDistance = _data.RoleMoveHorizontalSpeed * _data.RoleMoveHorizontalDuration;
            EditorGUILayout.LabelField(_data.RoleMoveHorizontalDistance.ToString());
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 横向运动位置
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("横向运动位置");
            nValue = EditorGUILayout.IntPopup((int)_data.RunState, arrVRunState, arrNvRunState);

            if (nValue != (int)_data.RunState)
            {
                _data.RunState = (eVRunState)nValue;
                EditorUtility.SetDirty(_data);
            }
            EditorGUILayout.EndHorizontal();
            #endregion
        }

    }

    public override void OnInspectorGUI()
    {

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
            EditorUtility.SetDirty(_data);
        }
        EditorGUILayout.EndHorizontal();

        #endregion

        switch (_data.RunMode)
        {
            case eRunMode.eRun_Horizontal:
                {
                    HorizontalMove();
                    break;
                }
            case eRunMode.eRun_Vertical:
                {
                    VerticalMove();
                    break;
                }
        }

    }


}
