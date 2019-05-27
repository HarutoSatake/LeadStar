using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIftRemake : MonoBehaviour
{
    [SerializeField]
    bool Move_Y = false;
    [SerializeField]
    bool Mirror = false;
    [SerializeField]
    float MoveSIze = 0.0f;
    [SerializeField]
    float Second = 0.0f;

    Vector3 Ini_pos;

    // Start is called before the first frame update
    void Start()
    {
        // 動いた距離を測るために初期値を記憶
        Ini_pos = this.transform.position;
        if (Mirror)
            Second *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move_Y == false)
            transform.position += Vector3.right * .1f;
        if (Time.timeScale != 0)
        {
            // sinグラフで反復運動
            float f = 1.0f / Second;
            float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
            Vector3 pos = this.transform.position;
            if (Move_Y)
            {
                pos.y = (sin * MoveSIze) + Ini_pos.y;
            }
            else
            {
                pos.x = (sin * MoveSIze) + Ini_pos.x;
            }
            transform.position = pos;
        }
    }
}
