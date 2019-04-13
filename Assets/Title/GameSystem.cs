using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    private void Start()
    {
        FadeManager.FadeIn();
    }
    // スタートボタンをクリックされた時
    void GameStart()
    {
        FadeManager.FadeOut(2);
    }
    // エンドボタンをクリックされた時
    void GameEnd()
    {
       UnityEditor.EditorApplication.isPlaying = false;
    }
}
