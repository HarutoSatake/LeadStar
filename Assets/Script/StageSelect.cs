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
    RectTransform SubStage;
    // 状態
    ChangeState State = ChangeState.SELECTING;
    // ボタンを変えるタイミング
    bool ChangeFlg = false;
    float count = 0;
    enum ChangeState
    {
        SELECTING,
        WAITING,
        PREVCHANGING,
        NEXTCHANGING
    }
    private void Start()
    {
        NowStage = Stage1;
        SubStage = Stage2;
    }
    private void Update()
    {
        if (ChangeFlg)
        {
            switch (State)
            {
                case ChangeState.SELECTING:
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case ChangeState.PREVCHANGING:
                    Cursor.lockState = CursorLockMode.Locked;
                    if (NowStage.localPosition.x < 1855)
                    {
                        NowStage.localPosition += new Vector3(35f, 0f, 0f);
                    }
                    if (NowStage.localPosition.x >= 1855)
                    {
                        State = ChangeState.WAITING;
                    }
                    break;
                case ChangeState.WAITING:
                    // 時間まで静止
                    if (count >= 0.5f)
                    {
                        count = 0;
                        State = ChangeState.NEXTCHANGING;
                    }
                    count += Time.deltaTime;
                    break;
                case ChangeState.NEXTCHANGING:
                    if (SubStage.localPosition.x > 0)
                    {
                        SubStage.localPosition += new Vector3(-35f, 0f, 0f);
                    }
                    if (SubStage.localPosition.x <= 0)
                    {
                        // ステージ関係の入れ替え
                        RectTransform w;
                        w = NowStage;
                        NowStage = SubStage;
                        SubStage = w;

                        State = ChangeState.SELECTING;
                    }
                    break;
            }
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
    public void Second_1()
    {
        FadeManager.FadeOut(7);
    }
    public void Second_2()
    {
        FadeManager.FadeOut(8);

    }
    public void Second_3()
    {
        FadeManager.FadeOut(9);
    }
    public void Second_4()
    {
        FadeManager.FadeOut(10);
    }
    public void Second_5()
    {
        FadeManager.FadeOut(11);
    }
    public void GoBackTitle()
    {
        FadeManager.FadeOut(0);
    }
    public void Change()
    {
        ChangeFlg = true;
        State = ChangeState.PREVCHANGING;
    }
}
