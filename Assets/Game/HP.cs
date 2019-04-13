using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] GameObject Star = null;

    private Text HpText = null;

    private int hp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        this.HpText = this.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        hp = Star.GetComponent<Star>().GetHP();

        this.HpText.text = "HP:" + hp;
    }
}
