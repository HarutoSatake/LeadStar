// マウスポインターのスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    float angle = 10.0f;
    Vector3 screenpoint = new Vector3(0,0,0);
    // Update is called once per frame
    void Update()
    {
        //カーソル表示非表示
        Cursor.visible = true;
        //ウィンドウ内のみ
        Cursor.lockState = CursorLockMode.Confined;
        // ある程度早く回転させたい

        transform.Rotate(0.0f, 0.0f,angle);
        this.screenpoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);
    }
}
