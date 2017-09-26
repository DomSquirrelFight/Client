
using UnityEngine;
using AttTypeDefine;

public class IniteBtn : MakeMove {

    public GameObject[] Btn;
    public string path;
    //音频路径
    public string m_strBtnClick;
    int indedx;
    void Start()
    {

        Global.UI = new GameObject[Btn.Length];
        for (int i = 0; i < Btn.Length; i++)
        {
            //Btn初始化
            GameObject button = Btn[i];
            button.transform.parent = Global.Button.transform;
           // button.transform.localScale = new Vector3(2, 0.5f, 1);
            Global.UI[i] = Btn[i];
            TrigClick tc = Btn[i].GetComponent<TrigClick>();
            tc.OnStart(i);
        }

        //初始化当前选中的button的位置
        GameObject CurButton = Instantiate(Resources.Load(path)) as GameObject;
        CurButton.transform.parent = Global.Button.transform;
        CurButton.transform.localPosition = Btn[0].transform.localPosition;
        CurButton.transform.localScale = Btn[0].transform.localScale;
        Global.CurBtn = CurButton;
        //UIEventListener.Get(Btn[BtnIndex]).onClick = Click;
        //UIEventListener.Get(obj).onClick = Click;

        //监听事件
        //UIEventListener.Get(Global.UI[indedx]).onClick = ClickBtn;
    }
    //执行click事件
   public  void ClickBtn(int i)
    {
        AudioManager.PlayAudio(null, eAudioType.Audio_UI, m_strBtnClick);
        if (Global.e_State == StateUI.State_Stay)
        {
            Global.Grid_CurrentIndex = i;
            Global.e_State = StateUI.State_Move;
        }
        //Global.e_State = StateUI.State_Stay;
        //Global.Grid_CurrentIndex = i;
        //Global.e_State = StateUI.State_Move;

    }
    //void Update()
    //{
    //if (Global.e_State == StateUI.State_Move)
    //{
    //    Debug.Log(Global.Grid_CurrentIndex);
    //    Debug.Log(Global.e_State);
    //    //MoveOutDrag(indedx);
    //    //MoveInmarginal(indedx);
    //    MoveByBtn(Global.Grid_CurrentIndex);

    //}
    //if ((Mathf.Abs(Global.Grid.transform.localPosition.x + (Global.Grid_CurrentIndex * Global.Grid_PerSize))) < 13f)
    //{
    //   // Debug.Log(Mathf.Abs(Global.Grid.transform.localPosition.x + (Global.Grid_CurrentIndex * Global.Grid_PerSize)));
    //    //MoveInmarginal(indedx);
    //    Global.e_State = StateUI.State_Stay;
    //}
    // MoveByBtn(Global.Grid_CurrentIndex);
    // MoveOutDrag(Global.Grid_CurrentIndex);
    //}
    protected override void Update()
    {
        base.Update();
    }
}
