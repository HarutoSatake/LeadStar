using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIft : MonoBehaviour
{
    [SerializeField]
    bool Move_Y = false;
    [SerializeField]
    bool Mirror = false;
    [SerializeField]
    float MoveSIze = 0;
    [SerializeField]
    float Second = 0;

    Vector3 Ini_pos;
    float moving_count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // 動いた距離を測るために初期値を記憶
        Ini_pos = this.transform.position;
        moving_count = 0;
        if (Mirror)
            Second *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        // ていうかこれsinグラフでよくね←イマココ
        
        float f = 1.0f / Second;
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
        Vector3 pos = this.transform.position;
        if(Move_Y)
        {
            pos.y = sin * MoveSIze;
        }
        else
        {
            pos.x = sin * MoveSIze;
        }
        transform.position = pos;
    }
}
