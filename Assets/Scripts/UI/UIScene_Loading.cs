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
    AnimState animState;
    #endregion

    #region 系统接口
    void Start()
    {
       
        StartCoroutine(SceneChange());
        DontDestroy();
        //DataReset();
        animState = AnimState.State_ProgressBar;
    }

    void Update()
    {
        #region 场景加载
        //进度条的加载
        if (animState == AnimState.State_ProgressBar)
        {
            TweenPosition.Begin(m_oBar, 1f, new Vector3(0, -280, 0)).method = UITweener.Method.BounceIn;
            //StartCoroutine(LaterDo());
            animState = AnimState.State_null;

        }
        if (animState == AnimState.State_null)
        {
            //资源预加载
            LoadRes();
            //进度条推进
            Invoke("ProcessBar", 2f);


        }
        #endregion

        #region tips加载
        if (!m_bIsChange)
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
    void LoadRes()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
        //复位所有全局引用
        //清理策划表实例缓存
        //if (type == SceneType.SelecteLoading)
        //{
        //}
        //if (type == SceneType.FightLoading)
        //{
        //}
    }
    #endregion

    #region 进度条推进
    //进度条推进
    UISlider us;
    void ProcessBar()
    {
        us = gameObject.GetComponent<UISlider>();
        if (us.value < 1)
        {
            us.value += m_fSpeed * Time.deltaTime;
        }
        else
        {

            Invoke("DestroyLoading", 2f);
            //DestroyLoading();
        }
    }
    #endregion

    #region 数据复位
    void DataReset()
    {
        us.value = 0;
        m_bIsChange = false;
        animState = AnimState.State_ProgressBar;
    }
#endregion

    #region 场景异步加载
    AsyncOperation asyn;
    IEnumerator SceneChange()
    {
        if(e_SceneGo==SceneGo.Fight)
        {
            asyn = GlobalHelper.LoadLevelAsync("ReduceDrawCall");
           // e_SceneGo = SceneGo.Go_null;
        }
        else if(e_SceneGo==SceneGo.Select)
        {
            asyn = GlobalHelper.LoadLevelAsync("Begin");
           // e_SceneGo = SceneGo.Go_null;
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
