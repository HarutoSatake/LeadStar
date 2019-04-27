using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYFP_System : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
    }

    public void TitleCall()
    {
        FadeManager.FadeOut(0);
    }
}
