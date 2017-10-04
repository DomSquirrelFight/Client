using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Helper;

public class UIScene_Start : MonoBehaviour {

    //背景图片的uisprite
    public UISprite m_Bg;
    AnimState anim;
    //动画播放速度、
    public float m_fPlaySpeed;
    bool m_bIsFirstLoaf = true;

	// Use this for initialization
	void Start () {
        //设置动画的初始状态
        anim = AnimState.State_BgAnim;
	}
     void Update()
    {

            if(m_Bg.fillAmount>=1f)
            {

            //播放完毕，切换状态
            //anim = AnimState.Start_PicAnim;
            if(m_bIsFirstLoaf)
            {
                Invoke("LoadLevel", 2f);
                m_bIsFirstLoaf = false;
            }
           
            }
            else
            {
                //播放的速度
                m_Bg.fillAmount += (m_fPlaySpeed * Time.deltaTime);
            }


    }
    //切换场景
    void LoadLevel()
    {
        Destroy(gameObject);
        //GlobalHelper.LoadLevel("Login");
        Helpers.UIScene<UIScene_Main>();
    }
}
