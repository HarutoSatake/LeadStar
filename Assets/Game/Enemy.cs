using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int count = 0;
    // 透明であるか否か
    bool active_flag = true;
    Vector3 ini_pos;
    // 透明度
    float red, green, blue;
    float alpha;
    private void Start()
    {
        // 初期値を保存
        ini_pos = this.transform.position;

        //red = this.GetComponent<Image>().color.r;
        //green = this.GetComponent<Image>().color.g;
        //blue = this.GetComponent<Image>().color.b;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したら透明にする
        if(collision.tag == "Star")
        {
            this.transform.position = ini_pos;
            //alpha = 0.0f;
            //GetComponent<Image>().color = new Color(red, green, blue, alpha);
            gameObject.SetActive(false);
            active_flag = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(active_flag == false)
        //{
        //    count++;
            
        //}        
        //if (count == 180)
        //{
        //    count = 0;
        //    alpha = 1.0f;
        //    GetComponent<Image>().color = new Color(red, green, blue, alpha);
        //    active_flag = true;
        //}
        
        //Debug.Log(active_flag);
    }
}
