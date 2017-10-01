using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadSceneRes()
    {
        if (GlobalHelper.BIsTest)                                   //如果是测试环境
        {

            StartPoint sp = null;

            UnityEngine.Object[] objs = Resources.LoadAll("Prefabs/Maps/FightTest");

            for (int i = 0; i < objs.Length; i++)
            {
                GameObject obj = Instantiate(objs[i]) as GameObject;
                obj.name = objs[i].name;
                if (obj.name.CompareTo("StartPoint") == 0)
                {
                    sp = obj.GetComponent<StartPoint>();
                }
            }

            if (null != sp)
                sp.OnStart();

        }
        //如果是正式环境
        else
        {

        }
    }
	
}
