using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarrySky_floating : MonoBehaviour
{
    Vector2 Ini_pos;
    float MoveSize = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // 動いた距離を測るために初期値を記憶
        Ini_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Sinグラフでふわふわします
        float f = 0.5f;
        float sin = Mathf.Sin(0.5f * Mathf.PI * f * Time.time);

        Vector3 pos = this.transform.position;
        pos.x = (sin * MoveSize) + Ini_pos.x;
        pos.y = (sin * MoveSize) + Ini_pos.y;

        transform.position = pos;
    }
}
