using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class UIScene_Fight : MonoBehaviour {

    BaseActor ba;
    BaseActor BA
    {
        get
        {
            if (null == ba)
            {
                //ba = GlobalHelper.g_GlobalLevel.Major;
            }
            return ba;
        }
    }
    //摇杆处理
    public GameObject m_oJoyBack;                                                                                  //摇杆背景对象
    public GameObject m_oJoyFront;                                                                                 //摇杆方向对象
    private Vector3 m_vJoyBackOrigPos;                                                                            //摇杆原始位置
    public float m_fRadius = 0.2f;                                                                                      //摇杆移动半径
    public GameObject m_oJump;                                                                                     //跳跃
    public GameObject m_oPickUpBox;                                                                             //捡箱子
    Camera cam;

    public void OnStart(BaseActor _owner)
    {
        ba = _owner;
    }
    void Awake()
    {
        UIEventListener.Get(m_oJump).onClick = PressJump;
        UIEventListener.Get(m_oPickUpBox).onClick = PressPickUpBox;
    }

    void PressJump(GameObject obj)
    {
        BA.PlayerMgr.CalJump();
        
    }

    void PressPickUpBox(GameObject obj)
    {
        BA.PlayerMgr.CalPickUpBox();
    }

    //认为最多不会超过10个
    bool[] m_bCanJoy = new bool[10];
	// Use this for initialization
	void Start () {
        m_oJoyBack.SetActive(false);

        m_vJoyBackOrigPos = m_oJoyBack.transform.position;

        cam = NGUITools.FindCameraForLayer(gameObject.layer);
	}
	
	void Update () {
#if UNITY_EDITOR
        MouseController();
#else
        TouchController ();
#endif
        if (m_oJoyFront.transform.localPosition.y > 0f)
        {
            m_oJoyFront.transform.localPosition = new Vector3(m_oJoyFront.transform.localPosition.x, 0f, m_oJoyFront.transform.localPosition.z);
        }
      }
    
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
                        if (!m_bCanJoy[i]) return;
                        m_oJoyBack.SetActive(false);//关闭活性
                        Debug.Log("TouchController :: TouchPhase.Ended");
                        dirpos = Vector2.zero;
                        //bpressed = false;
                        break;
                    }
                case TouchPhase.Canceled:
                    {
                      
                        if (!m_bCanJoy[i]) return;
                        Debug.Log("TouchController :: TouchPhase.Canceled");
                        dirpos = Vector2.zero;
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
            if (Input.mousePosition.x > Screen.width / 2f) {
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
            pos =  cam.ScreenToWorldPoint(Input.mousePosition);
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
        Vector2 vdir = m_oJoyFront.transform.position -  m_oJoyBack.transform.position;
        dirpos = new Vector2(vdir.x / m_fRadius, vdir.y / m_fRadius);
    }

    private Vector2 dirpos;
    public Vector2 DirPos
    {
        get
        {
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

}
