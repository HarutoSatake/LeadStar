using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearChecker : MonoBehaviour
{
    [SerializeField] GameObject ClearMesseage = null;
    [SerializeField] GameObject FailedMesseage = null;
    [SerializeField] GameObject StarParticle = null;
    [SerializeField] GameObject Star = null;
    [SerializeField] GameObject Goal = null;
    [SerializeField] GameObject Restart_Button = null;
    [SerializeField] GameObject Next_Button = null;
    [SerializeField] GameObject Stage_Button = null;
    [SerializeField] GameObject Back_Button = null;
    GameObject BGM = null;
    GameObject Pointer = null;
    //[SerializeField] GameObject E_Button = null;

    int nowscene = 0;
    int nextscene = 0;
    bool isPause = false;
    bool isGameEnd = false;
    private AudioSource s_Effect;
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
        BGM = GameObject.Find("BGM");
        Pointer = GameObject.Find("Pointer");

        nowscene = SceneManager.GetActiveScene().buildIndex;
        nextscene = nowscene + 1;
        ClearMesseage.SetActive(false);
        FailedMesseage.SetActive(false);

        Restart_Button.SetActive(false);
        Next_Button.SetActive(false);
        Stage_Button.SetActive(false);
        //E_Button.SetActive(false);
        Back_Button.SetActive(false);
        s_Effect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // パーティクルを発生させる
        if(Star.GetComponent<Stick_Star>().GetPflg())
        {
            GameObject Particle = Instantiate(StarParticle) as GameObject;
            Vector3 pos = Star.GetComponent<Transform>().position;
            Particle.transform.position = pos;
        }

        // ポーズ処理
        if(Input.GetKeyDown(KeyCode.Escape) && !isGameEnd)
        {
            // ポーズ中の場合TimeScaleを元に戻す
            if (isPause)
            {
                Time.timeScale = 1f;
                // ボタン非活性化
                Back_Button.SetActive(false);
                Stage_Button.SetActive(false);
                Restart_Button.SetActive(false);
                Pointer.SetActive(true);

                isPause = false;
            }
            // ポーズ中ではなかった場合TImeScaleを0にする
            else if (!isPause)
            {
                Time.timeScale = 0f;
                s_Effect.PlayOneShot(s_Effect.clip);
                // ボタン活性化
                Back_Button.SetActive(true);
                Stage_Button.SetActive(true);
                Restart_Button.SetActive(true);
                Pointer.SetActive(false);
                // 位置調整
                Restart_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Restart_Button, 0.0f, -155.0f);
                Stage_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Stage_Button, 0.0f, -360.0f);
                Back_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Restart_Button, 0.0f, 38.0f);
                isPause = true;
            }
            
            
        }
        // ゲームクリア処理
        if(Goal.GetComponent<Goal>().GetFlg())
        {
            ClearMesseage.SetActive(true);

            // ボタン活性化
            Next_Button.SetActive(true);
            Stage_Button.SetActive(true);
            Restart_Button.SetActive(true);

            // 位置調整
            Restart_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Restart_Button, 0.0f, -155.0f);
            Stage_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Stage_Button, 0.0f, -360.0f);
            Next_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Restart_Button, 0.0f, 38.0f);

            isGameEnd = true;
            
        }
        // ゲーム失敗時
        if(Star.GetComponent<Stick_Star>().GetHP() <= 0)
        {
            FailedMesseage.SetActive(true);

            // ボタン活性化
            Restart_Button.SetActive(true);
            Stage_Button.SetActive(true);
            //E_Button.SetActive(true);

            // 位置調整
            Restart_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Restart_Button, 0.0f, 38.0f);
            Stage_Button.GetComponent<RectTransform>().anchoredPosition = RectPos(Stage_Button, 0.0f, -155.0f);

            isGameEnd = true;
        }
    }

    public void RestartButton()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        Time.timeScale = 1f;
        FadeManager.FadeOut(nowscene);
    }
    public void StageSelectButton()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        Time.timeScale = 1f;
        FadeManager.FadeOut(1);
        Destroy(BGM);
    }
    public void NextButton()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        Time.timeScale = 1f;
        if(nextscene == 12)
            Destroy(BGM);
        FadeManager.FadeOut(nextscene);
        
    }
    public void BuckButton()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        Time.timeScale = 1f;

        // ボタン非活性化
        Back_Button.SetActive(false);
        Stage_Button.SetActive(false);
        Restart_Button.SetActive(false);

        isPause = false;
    }

    //public void TitleCall()
    //{
    //    FadeManager.FadeOut(0);
    //}

    // RectTransForm.Position移動
    Vector2 RectPos(GameObject _obj,float _x,float _y)
    {
        Vector2 pos = _obj.gameObject.GetComponent<RectTransform>().anchoredPosition;
        pos = new Vector2(_x,_y);
        return pos;
    }
}