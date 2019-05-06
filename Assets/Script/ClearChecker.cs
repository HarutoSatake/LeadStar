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
    [SerializeField] GameObject BGM = null;
    //[SerializeField] GameObject E_Button = null;

    int nowscene = 0;
    int nextscene = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();

        nowscene = SceneManager.GetActiveScene().buildIndex;
        nextscene = nowscene + 1;
        ClearMesseage.SetActive(false);
        FailedMesseage.SetActive(false);

        Restart_Button.SetActive(false);
        Next_Button.SetActive(false);
        Stage_Button.SetActive(false);
        //E_Button.SetActive(false);
        Back_Button.SetActive(false);

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

        }
    }

    public void RestartButton()
    {
        FadeManager.FadeOut(nowscene);
    }
    public void StageSelectButton()
    {
        FadeManager.FadeOut(1);
        BGM.GetComponent<NoDestroyObj>().SetDestroy(true);
    }
    public void NextButton()
    {
        FadeManager.FadeOut(nextscene);
        BGM.GetComponent<NoDestroyObj>().SetDestroy(true);
    }
    public void BuckButton()
    {

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