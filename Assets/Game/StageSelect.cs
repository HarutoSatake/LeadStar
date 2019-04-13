using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
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
