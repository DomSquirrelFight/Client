using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_Start : MonoBehaviour {
    public GameObject m_btn;
    public GameObject m_panel;
    public UISprite m_Bg;
    AnimState anim;
    //动画播放速度、
    public float m_fPlaySpeed;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_btn).onClick = PressBtn;
        //设置动画的初始状态
        anim = AnimState.Start_BgAnim;
        //初始化pic和btn，让他们出生在屏幕的外边
        m_panel.transform.localPosition = new Vector3(0, -999, 0);

	}
	void PressBtn(GameObject obj)
    {
        //切换场景到登录场景
        GlobalHelper.LoadLevel("Login");
    }
     void Update()
    {
        //在加载背景图片的时候，播放本身的动画
        if(anim==AnimState.Start_BgAnim)
        {
            if(m_Bg.fillAmount>=1f)
            {
                //播放完毕，切换状态
                anim = AnimState.Start_PicAnim;
            }
            else
            {
                //播放的速度
                m_Bg.fillAmount += (m_fPlaySpeed * Time.deltaTime);
            }
        }
        //加载button和屏幕中的pic的时候，运动bouchin，加载完毕，把状态置空
        if (anim==AnimState.Start_PicAnim)
        {
           TweenPosition.Begin(m_panel, 2f, new Vector3(0, 0, 0)).method = UITweener.Method.BounceIn;
            Destroy(m_btn.GetComponent<TweenPosition>());
            anim = AnimState.Start_null;
        }
    }
}
