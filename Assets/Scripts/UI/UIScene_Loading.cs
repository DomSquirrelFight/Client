using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefined;
using System;

public class UIScene_Loading : UIScene {
    public float m_fSpeed;
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
	}
 
	// Update is called once per frame
	void Update () {
        
            //资源预加载
            LoadRes(eScene);
            //进度条推进
            ProcessBar();
            //场景切换
            SceneChange(eScene);
            eState = LoadingState.e_Null;
            
        
        

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

        }
    }
    IEnumerator LateDestroy()
    {
        yield return new WaitForSeconds(0.5f);
    }
    //场景切换
    AsyncOperation asyn;
    IEnumerator SceneChange(SceneType type)
    {
        //加载新的场景
        if(type==SceneType.FightLoading)
        {
            asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("FightTest");
        }
        if(type==SceneType.SelecteLoading)
        {
            asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Selecte");
        }
      

        yield return asyn;
    }

    //销毁loading
    void DestroyLoading()
    {
        Destroy(gameObject);
    }
    //不可销毁
    void DontDestroy()
    {
        GameObject.DontDestroyOnLoad(transform.parent.transform.parent);
    }
    
}
