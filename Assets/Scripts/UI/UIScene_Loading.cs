using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using System;

public class UIScene_Loading : UIScene {
    #region 成员变量
    //进度条速度
    public float m_fSpeed;
    //背景图片
    public UISprite m_uBg;
    AnimState animState;
    //Bar的实例
    public GameObject m_oBar;
    //tipslist,共有型，可以在inspector中进行添加
    public List<string> m_lTips;
    //当前显示的tips的序号
    int m_CurIndex;
    //bool值用来控制是否是需要取加载改变随机数字
    bool m_bIsChange = false;
    //label用来存储要显示的tip
    public UILabel m_Tip;
    #endregion

    #region 系统接口
    void Start()
    {
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
        animState = AnimState.State_BgAnim;
    }

    // Update is called once per frame
    void Update()
    {
        #region 场景加载
        //背景图的加载
        if (animState == AnimState.State_BgAnim)
        {
            if (m_uBg.fillAmount >= 1f)
            {
                animState = AnimState.State_ProgressBar;
            }
            else
            {
                m_uBg.fillAmount += 2f * Time.deltaTime;
            }
        }
        //pic的加载
        //if (animState == AnimState.Start_PicAnim)
        //{
        //    //TweenPosition.Begin(m_oPic, 2f, new Vector3(0, 0, 0)).method = UITweener.Method.BounceIn;
        //    animState = AnimState.Start_ProgressBar;
        //}
        //进度条的加载
        if (animState == AnimState.State_ProgressBar)
        {
            TweenPosition.Begin(m_oBar, 1f, new Vector3(-450, -280, 0)).method = UITweener.Method.BounceIn;
            //StartCoroutine(LaterDo());
            animState = AnimState.State_null;

        }
        if (animState == AnimState.State_null)
        {
            //资源预加载
            LoadRes(eScene);
            //进度条推进
            Invoke("ProcessBar", 2f);
            

        }
        #endregion

        #region tips加载
        if(!m_bIsChange)
        {
            Invoke("RandomIndex", 3f);
            m_Tip.text = m_lTips[m_CurIndex];
            m_bIsChange = true;

        }
#endregion
    }
    #endregion

    #region 资源预加载
    //场景资源预加载
    void LoadRes(SceneType type)
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
        //复位所有全局引用
        //清理策划表实例缓存
        if (type == SceneType.SelecteLoading)
        {
        }
        if (type == SceneType.FightLoading)
        {
        }
    }
    #endregion

    #region 进度条推进
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
            // StartCoroutine(LaterDo());
            //DestroyLoading();s
            Invoke("DestroyLoading", 2f);
            //场景切换
            //DestroyLoading();
        }
    }
    #endregion

    //延迟销毁
    //IEnumerator LaterDo()
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(5);
    //    }

    //}
    //场景切换，异步加载

    #region 场景异步加载
    AsyncOperation asyn;
    IEnumerator SceneChange(SceneType type)
    {
        //异步加载新的场景
        if (type == SceneType.FightLoading)
        {
            asyn = GlobalHelper.LoadLevelAsync("Map_Test_Fight");
            // type = SceneType.Null;
        }
        if (type == SceneType.SelecteLoading)
        {
            // asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SelecteV1");
            asyn = GlobalHelper.LoadLevelAsync("SelecteV1");
            // type = SceneType.Null;
        }
        yield return asyn;
    }
    #endregion

    #region 销毁
    //销毁loading
    void DestroyLoading()
    {
        eState = LoadingState.e_StartTime;
        Destroy(gameObject);
        
    }
    //不可销毁游戏对象
    void DontDestroy()
    {
        GameObject.DontDestroyOnLoad(transform.parent.transform.parent);
    }
    #endregion

    #region 随机选取list中的字符串
    void RandomIndex()
    {
        int i = UnityEngine.Random.Range(0, m_lTips.Count);
        m_CurIndex = i;
        m_bIsChange = false;
    }
        #endregion
 }
