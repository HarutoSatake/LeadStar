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
    [SerializeField] GameObject R_Button = null;
    [SerializeField] GameObject N_Button = null;
    [SerializeField] GameObject S_Button = null;
    [SerializeField] GameObject E_Button = null;
    [SerializeField] GameObject B_Button = null;
   
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

        R_Button.SetActive(false);
        N_Button.SetActive(false);
        S_Button.SetActive(false);
        E_Button.SetActive(false);
        B_Button.SetActive(false);
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

            N_Button.SetActive(true);
            S_Button.SetActive(true);
            E_Button.SetActive(true);
        }
        if(Star.GetComponent<Stick_Star>().GetHP() <= 0)
        {
            FailedMesseage.SetActive(true);

            R_Button.SetActive(true);
            S_Button.SetActive(true);
            E_Button.SetActive(true);
        }
    }

    public void RestartButton()
    {
        FadeManager.FadeOut(nowscene);
    }
    public void StageSelectButton()
    {
        FadeManager.FadeOut(1);
    }
    public void NextButton()
    {
        FadeManager.FadeOut(nextscene);
    }
    public void BuckButton()
    {

    }
    public void TitleCall()
    {
        FadeManager.FadeOut(0);
    }
}
