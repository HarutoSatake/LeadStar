using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField]
    GameObject Star = null;

    float Percentage;
    // Start is called before the first frame update
    void Start()
    {
        int hp = Star.GetComponent<Stick_Star>().GetHP();

        Percentage = hp / 1.0f;
    }

    public void DecreaseHp()
    {
        
    }
}
