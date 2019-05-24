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
    GameObject Stage2 = null;
    private void Start()
    {
    }
    private void Update()
    {
       
        Stage1.localPosition += new Vector3(1, 0, 0);
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
