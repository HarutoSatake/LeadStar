using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    RectTransform Stage1 = null;
    [SerializeField]
    RectTransform Stage2 = null;

    // 今選択されているステージ
    RectTransform NowStage;
    // 次に選択されるステージ
    RectTransform NextStage;
    // 前に選択されるステージ
    RectTransform PrevStage;
    // 状態
    ChangeState State = ChangeState.CHANGING;
    enum ChangeState
    {
        SELECTING,
        CHANGING,
    }
    private void Start()
    {
        NowStage = Stage1;
    }
    private void Update()
    {
        switch(State)
        {
            case ChangeState.SELECTING:
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("せれくてぃんぐなう");
                break;
            case ChangeState.CHANGING:
                Cursor.lockState = CursorLockMode.Locked;
                if (Stage1.localPosition.x < 1855)
                {
                    Stage1.localPosition += new Vector3(35f, 0f, 0f);
                }
                else if (Stage1.localPosition.x == 1855)
                {
                    State = ChangeState.SELECTING;
                }
                Debug.Log("ちぇんじんぐなう");
                break;

        }
        
    }
    public void First_1()
    {
        FadeManager.FadeOut(2);
    }
    public void First_2()
    {
        FadeManager.FadeOut(3);
    }
    public void First_3()
    {
        FadeManager.FadeOut(4);
    }
    public void First_4()
    {
        FadeManager.FadeOut(5);
    }
    public void First_5()
    {
        FadeManager.FadeOut(6);
    }
    public void GoBackTitle()
    {
        FadeManager.FadeOut(0);
    }
}
