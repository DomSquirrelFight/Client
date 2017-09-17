using System.Collections;
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
    //pic的实例
    public GameObject m_oPic;
    //Bar的实例
    public GameObject m_oBar;
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
            TweenPosition.Begin(m_oPic, 2f, new Vector3(0, 0, 0)).method = UITweener.Method.BounceIn;
            animState = AnimState.Start_ProgressBar;
        }
       //进度条的加载
       if(animState==AnimState.Start_ProgressBar)
        {
            TweenPosition.Begin(m_oBar, 1f, new Vector3(0, -200, 0)).method = UITweener.Method.BounceIn;
            //StartCoroutine(LaterDo());
            animState = AnimState.Start_null;
           
        }
        else if(animState==AnimState.Start_null)
        {
            //资源预加载
            LoadRes(eScene);
            //进度条推进
            Invoke("ProcessBar", 2f);
           
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
            Debug.Log("Selecte");
        }
        if (type == SceneType.FightLoading)
        {
            Debug.Log("Fight");
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
            StartCoroutine(LaterDo());
            //DestroyLoading();
            Invoke("DestroyLoading", 1f);
            //场景切换
          // SceneChange(eScene);
        }
    }
    //延迟销毁
    IEnumerator LaterDo()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
        }

    }
    //场景切换，异步加载
    AsyncOperation asyn;
    IEnumerator SceneChange(SceneType type)
    {
        //异步加载新的场景
        if(type==SceneType.FightLoading)
        {
            asyn =GlobalHelper.LoadLevelAsync("Fight");
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
