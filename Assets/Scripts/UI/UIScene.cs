using UnityEngine;
using AttTypeDefine;

public class UIScene : MonoBehaviour {
    protected static LoadingState eState = LoadingState.e_Null;
    protected SceneType eScene;
    //弹出ui的销毁按钮
    protected virtual void ClickBtn(GameObject obj)
    {
        Destroy(gameObject);
    }
}
