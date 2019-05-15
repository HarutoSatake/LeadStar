using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    GameObject MenuStar = null;
    [SerializeField]
    GameObject ClickParticle = null;

    private AudioSource s_Effect;

    float Percentage = 0.0f;
    private void Start()
    {
        FadeManager.FadeIn();

        s_Effect = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Star = Instantiate(MenuStar) as GameObject;
            
            GameObject Particle = Instantiate(ClickParticle) as GameObject;
            Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
            Particle.transform.position = Camera.main.ScreenToWorldPoint(a);
        }
    }
    // スタートボタンをクリックされた時
    void GameStart()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        FadeManager.FadeOut(1);
    }
    // エンドボタンをクリックされた時
    void GameEnd()
    {
        s_Effect.PlayOneShot(s_Effect.clip);
        UnityEngine.Application.Quit();
    }
}
