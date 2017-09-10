﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System;

public class UIScene_Loading : UIScene {
    //进度条速度
    public float m_fSpeed;
    //背景图片
    public UISprite m_uBg;
    AnimState animState;
	// Use this for initialization
	void Start () {
        if (eState == LoadingState.e_LoadLevel)
        {
            eScene = SceneType.FightLoading;
        }
        else if (eState == LoadingState.e_LoadSelect)
        {
            eScene = SceneType.SelecteLoading;
        }
        StartCoroutine(SceneChange(eScene));
        DontDestroy();
        animState = AnimState.Start_BgAnim;
	}
 
	// Update is called once per frame
	void Update () {
        //背景图的加载
        if(animState==AnimState.Start_BgAnim)
        {
            if(m_uBg.fillAmount>=1f)
            {
                animState = AnimState.Start_PicAnim;
            }
            else
            {
                m_uBg.fillAmount += 2f;
            }
        }
        //pic的加载
        if(animState==AnimState.Start_PicAnim)
        {

        }
       //进度条的加载
       if(animState==AnimState.Start_ProgressBar)
        {

        }
        else
        {
            //资源预加载
            LoadRes(eScene);
            //进度条推进
            ProcessBar();
            eState = LoadingState.e_Null;
        }

    }
    //场景资源预加载
    void LoadRes(SceneType type)
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
        //复位所有全局引用
        //清理策划表实例缓存
        if(type==SceneType.SelecteLoading)
        {

        }
        if (type == SceneType.FightLoading)
        {

        }
    }
    //进度条推进
    void ProcessBar()
    {
        UISlider us = gameObject.GetComponent<UISlider>();
        if (us.value < 1)
        {
            us.value += m_fSpeed * Time.deltaTime;
        }
        else
        {
            //进度条走到百分之百，资源销毁
            StartCoroutine(LateDestroy());
            DestroyLoading();
            //场景切换
          // SceneChange(eScene);
        }
    }
    //延迟销毁
    IEnumerator LateDestroy()
    {
        yield return new WaitForSeconds(0.5f);
    }
    //场景切换，异步加载
    AsyncOperation asyn;
    IEnumerator SceneChange(SceneType type)
    {
        //异步加载新的场景
        if(type==SceneType.FightLoading)
        {
            asyn =GlobalHelper.LoadLevelAsync("FightTest");
           // type = SceneType.Null;
        }
        if(type==SceneType.SelecteLoading)
        {
            // asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SelecteV1");
            asyn = GlobalHelper.LoadLevelAsync("SelecteV1");
           // type = SceneType.Null;
        }
        yield return asyn;
    }
    //销毁loading
    void DestroyLoading()
    {
        Destroy(gameObject);
    }
    //不可销毁游戏对象
    void DontDestroy()
    {
        GameObject.DontDestroyOnLoad(transform.parent.transform.parent);
    }
    
}
