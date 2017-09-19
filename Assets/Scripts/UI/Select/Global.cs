using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class Global : MonoBehaviour {
    //用来存放button和item的父类
    public static GameObject Grid;
    public static GameObject Button;
    //当前的button，让选中button跟随
    public static GameObject CurBtn;
    //存放button
    public static GameObject[] UI;
    public static int Grid_Count;
    public static float Grid_PerSize;
    public static int Grid_CurrentIndex;
    public static string Scene_Go;
    public static StateUI e_State = StateUI.State_Stay;
}
