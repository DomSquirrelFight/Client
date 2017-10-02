using UnityEngine;
using AttTypeDefine;

public class UIScene : MonoBehaviour {
    protected  LoadingState eState = LoadingState.e_Null;
    protected SceneType eScene;
    protected static DragState dragstate=DragState.State_Drag;
    //弹出ui的销毁按钮
    protected virtual void ClickBtn(GameObject obj)
    {
        Destroy(gameObject);
    }
}
