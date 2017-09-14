using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class Global : MonoBehaviour {
    public static GameObject Grid;
    public static GameObject Button;
    public static GameObject CurBtn;
    public static GameObject[] UI;
    public static int Grid_Count;
    public static float Grid_PerSize;
    public static int Grid_CurrentIndex;
    public static string Scene_Go;
    public static StateUI e_State = StateUI.State_Stay;
}
