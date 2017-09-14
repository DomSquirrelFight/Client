using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniteCard : MonoBehaviour {
    public GameObject[] Card;
    public float Width;
    //list 用来存储每一个ui的label信息
    List<UserData> LabelInfo = new List<UserData>();
    // Use this for initialization
    void Start () {
        Global.Grid_PerSize = Width;
        Global.Grid_Count = Card.Length;
        CardInited();

	}
    void CardInited()
    {
        for (int i = 0; i < Card.Length; i++)
        {
            //item加载
            GameObject card = Card[i];
            //设置初始化
            card.transform.localPosition = new Vector3(i * Width, 0, 0);
            card.transform.localScale = Vector3.one;
            ////加载label信息
            //UserData data = LabelInfo[i];
            ////遍历子游戏对象，给label赋值
            //UILabel[] Label = card.GetComponentsInChildren<UILabel>();
            //Label[0].text = data.age;
            //Label[1].text = data.height;
            //Label[2].text = data.name;
        }
    }
    //获得label数据
    void LoadSQL()
    {
        for (int i = 0; i < Card.Length; i++)
        {
            string name = "";
            string age = "";
            string height = "";
            LabelInfo.Add(new UserData(name, age, height));
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
