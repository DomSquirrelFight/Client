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
    public GameObject m_oJoyBack;
    public GameObject m_oJoyFront;
    private Vector3 m_vJoyBackOrigPos;//摇杆原始位置
    public float m_fRadius = 0.2f;
    public GameObject m_oNormalAttack;
    public GameObject m_oSkill1;
    Camera cam;

    public void OnStart(BaseActor _owner)
    {
        ba = _owner;
    }
    void Awake()
    {
        UIEventListener.Get(m_oNormalAttack).onClick = PressNormalAttack;
        UIEventListener.Get(m_oSkill1).onClick = PressSkill1;
    }

    void PressNormalAttack(GameObject obj)
    {
        //BA.SkillMgr.UseSkill(eSkillType.NormalAttack);
    }

    void PressSkill1(GameObject obj)
    {
        //BA.SkillMgr.UseSkill(eSkillType.Skill1);
    }

    //认为最多不会超过10个
    bool[] m_bCanJoy = new bool[10];
	// Use this for initialization
	void Start () {
        m_oJoyBack.SetActive(false);

        m_vJoyBackOrigPos = m_oJoyBack.transform.position;

        cam = NGUITools.FindCameraForLayer(gameObject.layer);
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        MouseController();
#else
        TouchController ();
#endif
      }

    bool bpressed = false;
    public bool PRESSED
    {
        get
        {
            return bpressed;
        }
    }
    bool bTouchJoy = false;
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
                        bpressed = m_bCanJoy[i] = true;
                        TouchPos = cam.ScreenToWorldPoint(touch.position);//获取点击起点位置
                        m_oJoyFront.transform.localPosition = Vector3.zero;
                        m_oJoyBack.transform.position = m_vJoyBackOrigPos = TouchPos;//赋值给起点游戏对象
                        m_oJoyBack.SetActive(true);
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        if (!m_bCanJoy[i]) return;
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
                        bpressed = false;
                        break;
                    }
                case TouchPhase.Canceled:
                    {
                        if (!m_bCanJoy[i]) return;
                        break;
                    }
                case TouchPhase.Stationary:
                    {
                        if (!m_bCanJoy[i]) return;
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
            bpressed = true;
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
            bpressed = false;
        }
    }

    void CalculateDir()
    {
        Vector2 vdir = m_oJoyFront.transform.position -  m_oJoyBack.transform.position;
        dirpos = new Vector2(vdir.x / m_fRadius, vdir.y / m_fRadius);
        //dir = Mathf.Atan2(vdir.x, vdir.y) * Mathf.Rad2Deg;
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
