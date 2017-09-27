using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class UIScene_Fight : UIScene
{
    #region 摇杆，跳跃，具箱子事件处理
    BaseActor ba;
    //摇杆处理
    public GameObject m_oJoyBack;                                                                                  //摇杆背景对象
    public GameObject m_oJoyFront;                                                                                 //摇杆方向对象
    private Vector3 m_vJoyBackOrigPos;                                                                            //摇杆原始位置
    public float m_fRadius = 0.1f;                                                                                      //摇杆移动半径
    public GameObject m_oJumpUp;                                                                                     //上跳
    public GameObject m_oJumpDown;
    public GameObject m_oPickUpBox;                                                                             //捡箱子
    Camera cam;
    bool m_bPressedJumpUp = false;                                                                                //判定是否按下了上跳
    bool m_bPressedJumpDown = false;                                                                           //判定是否按下了下跳
    
    public UIButtonColor JumpDownBtnColor;
    public BoxCollider JumpDownBC;

    private bool bdisablejumpdown = false;
    public bool BDisableJumpDown
    {
        get
        {
            return bdisablejumpdown;
        }
        set
        {

            if(value == true)
            {
                JumpDownBtnColor.SetState(UIButtonColor.State.Disabled, true);
            }
            else
            {
                JumpDownBtnColor.SetState(UIButtonColor.State.Normal, true);
            }
            JumpDownBC.enabled = !value;

            if (value != bdisablejumpdown)
            {
                bdisablejumpdown = value;
            }
               
        }
    }

    public void OnStart(BaseActor _owner)
    {
        ba = _owner;
       
    }


    void PressJumpUp(GameObject obj, bool pressed)
    {
        m_bPressedJumpUp = pressed;
    }

    void PressJumpDown(GameObject obj, bool pressed)
    {
        if (!BDisableJumpDown)
                m_bPressedJumpDown = pressed;
    }

    void PressPickUpBox(GameObject obj)
    {
        ba.SkillMgr.UseSkill(eSkillType.SkillType_ThrowBox);
    }

    //认为最多不会超过10个
    bool[] m_bCanJoy = new bool[10];
    // Use this for initialization


    Vector3 TouchPos;
    void TouchController()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        if (touch.position.x > Screen.width / 2f)
                        {
                            m_bCanJoy[i] = false;
                            return;
                        }
                        m_bCanJoy[i] = true;
                        TouchPos = cam.ScreenToWorldPoint(touch.position);//获取点击起点位置
                        m_oJoyFront.transform.localPosition = Vector3.zero;
                        m_oJoyBack.transform.position = m_vJoyBackOrigPos = TouchPos;//赋值给起点游戏对象
                        m_oJoyBack.SetActive(true);
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        if (!m_bCanJoy[i]) return;
                        Debug.Log("TouchController :: TouchPhase.Moved");
                        TouchPos = cam.ScreenToWorldPoint(touch.position);
                        CalculateDir();
                        if (Vector3.Distance(TouchPos, m_oJoyBack.transform.position) >= m_fRadius)
                        {
                            m_oJoyFront.transform.localPosition = m_oJoyBack.transform.InverseTransformPoint(m_vJoyBackOrigPos + (TouchPos - m_vJoyBackOrigPos).normalized * m_fRadius);
                        }
                        else
                        {
                            m_oJoyFront.transform.localPosition = m_oJoyBack.transform.InverseTransformPoint(TouchPos);
                        }
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        dirpos = Vector2.zero;
                        if (!m_bCanJoy[i]) return;
                        m_oJoyBack.SetActive(false);//关闭活性
                        Debug.Log("TouchController :: TouchPhase.Ended");
                        //bpressed = false;
                        break;
                    }
                case TouchPhase.Canceled:
                    {
                        dirpos = Vector2.zero;
                        if (!m_bCanJoy[i]) return;
                        Debug.Log("TouchController :: TouchPhase.Canceled");
                       
                        break;
                    }
                case TouchPhase.Stationary:
                    {
                        if (!m_bCanJoy[i]) return;
                        Debug.Log("TouchController :: TouchPhase.Stationary");
                        //dirpos = Vector2.zero;
                        break;
                    }
            }

        }
    }
    Vector3 pos;
    bool bCanJoy = false;
    void MouseController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2f)
            {
                bCanJoy = false;
                return;
            }
            bCanJoy = true;
            //bpressed = true;
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            m_oJoyFront.transform.localPosition = Vector3.zero;
            m_oJoyBack.transform.position = m_vJoyBackOrigPos = pos;
            m_oJoyBack.SetActive(true);
        }
        else if (Input.GetMouseButton(0))
        {
            if (!bCanJoy) return;
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            CalculateDir();
            if (Vector3.Distance(pos, m_vJoyBackOrigPos) >= m_fRadius)
            {
                m_oJoyFront.transform.localPosition = m_oJoyBack.transform.InverseTransformPoint(m_vJoyBackOrigPos + (pos - m_vJoyBackOrigPos).normalized * m_fRadius);
            }
            else
            {
                m_oJoyFront.transform.localPosition = m_oJoyBack.transform.InverseTransformPoint(pos);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!bCanJoy) return;
            m_oJoyBack.SetActive(false);
            //bpressed = false;
            dirpos = Vector2.zero;
        }
    }

    void CalculateDir()
    {
        Vector2 vdir = m_oJoyFront.transform.position - m_oJoyBack.transform.position;
        dirpos = new Vector2(vdir.x / m_fRadius, vdir.y / m_fRadius);
    }

    private Vector2 dirpos;
    public Vector2 DirPos
    {
        get
        {
            float x = dirpos.x;
            if (x < 0f)
                dirpos.x = -1f;
            else if (x > 0)
                dirpos.x = 1f;
            else
                dirpos.x = 0f;
            return dirpos;
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < 10; i++)
        {
            m_bCanJoy[i] = false;
        }
    }
    #endregion

    #region 系统接口
    void Awake()
    {
        UIEventListener.Get(m_oJumpUp).onPress = PressJumpUp;
        UIEventListener.Get(m_oPickUpBox).onClick = PressPickUpBox;
        UIEventListener.Get(m_oJumpDown).onPress = PressJumpDown;
        UIEventListener.Get(m_oLeaveBtn).onClick = LeaveScene;
        UIEventListener.Get(m_oOverBtn).onClick = EndTheGame;
    }

    void Start()
    {
       
        m_oJoyBack.SetActive(false);

        m_vJoyBackOrigPos = m_oJoyBack.transform.position;

        cam = NGUITools.FindCameraForLayer(gameObject.layer);

        
        //m_LifeNum = m_uiLife.Length;
        m_LifeNum = ba.BaseAtt[eAttInfo.AttInfo_HP];



    }

    void Update()
    {
        if (m_bPressedJumpUp)
            ba.PlayerMgr.CalJumpUp();       //上跳
        else if (m_bPressedJumpDown)
            ba.PlayerMgr.CalJumpDown();  // 下跳

#if UNITY_EDITOR
        MouseController();
#else
        TouchController ();
#endif
        if (m_oJoyFront.transform.localPosition.y > 0f)
        {
            m_oJoyFront.transform.localPosition = new Vector3(m_oJoyFront.transform.localPosition.x, 0f, m_oJoyFront.transform.localPosition.z);
        }
        if (eState == LoadingState.e_StartTime)
        {
            m_nCurTime = m_nTotalTime;
            InvokeRepeating("CountTime", 0f, 1f);
            eState = LoadingState.e_Null;
        }
    }


    #endregion

    #region 离开游戏
    public GameObject m_oLeaveBtn;
    void LeaveScene(GameObject obj)
    {
        //退出离开游戏，跳转到login界面
        GlobalHelper.LoadLevel("Login");
    }
    #endregion

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 100, 100), "Press"))
    //    {
    //        //GetScore(10);
    //        BeInjured();
    //        Debug.Log(m_LifeNum);
    //    }
    //}

    #region 生命值
    public UISprite[] m_uiLife;
    int m_LifeNum;
    public void BeInjured()
    {
        m_LifeNum--;
        if(m_LifeNum<0)
        {
            Gameover();
        }
        else
        {
            m_uiLife[m_LifeNum].enabled = false;
        }
        
    }
    #endregion

    #region 分数值

    public UILabel m_labelScore;
    public TweenScale m_tsLabelScore;
    int m_nCurScore = 0;
    public void GetScore(int num)
    {
        m_tsLabelScore.ResetToBeginning();
        m_tsLabelScore.enabled = true;
        m_nCurScore += num;
        m_labelScore.text = m_nCurScore.ToString();
    }
    #endregion

    #region 倒计时
    const int m_nTotalTime = 60;
    private int m_nCurTime;
    public UILabel m_labelTimeCounter;
    string leftTime;
    void CountTime()
    {
        
        m_nCurTime--;
        if (m_nCurTime < 10)
        {
            leftTime = "0" + m_nCurTime.ToString();
        }
        else
            leftTime = m_nCurTime.ToString();

        m_labelTimeCounter.text = "00 : " + leftTime;
        if(m_nCurTime == 0)
        {
            Gameover();
        }
    }
    #endregion

    #region 游戏结束界面
    public GameObject m_oGameOver;
    public UILabel m_uiTotalScore;
    public GameObject m_oOverBtn;
    void Gameover()
    {
        Time.timeScale = 0f;
        //Gameover界面的活性打开
        m_oGameOver.SetActive(true);
        //显示最终得分
        m_uiTotalScore.text = "Total Score=" + m_labelScore.text;
    }
    void EndTheGame(GameObject obj)
    {
        GlobalHelper.LoadLevel("SelecteV1");
    }
#endregion
}
