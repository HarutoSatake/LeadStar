using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    GameObject MenuStar = null;
    [SerializeField] GameObject ClickParticle = null;
    private void Start()
    {
        FadeManager.FadeIn();
        
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
        FadeManager.FadeOut(1);
    }
    // エンドボタンをクリックされた時
    void GameEnd()
    {
        UnityEngine.Application.Quit();
    }
}
