using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionBtnController : MonoBehaviour
{
    public void OptionSelect(bool isShow)
    {
        // UiManager의 옵션 Ui 띄우는 기능 호출
        SceneUiManager.Instance.GameOptionUi(isShow);
    }

    public void ExitSelect(bool isShow)
    {
        // UiManager의 종료 Ui 띄우는 기능 호출
        SceneUiManager.Instance.GameExitUi(isShow);
    }
}
