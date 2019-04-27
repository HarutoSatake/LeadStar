using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStar : MonoBehaviour
{
    Rigidbody2D rigid2D = null;

    Vector2 vec = new Vector2(0, 0);
    private const float speeds = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        // リジッドボディを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

        Vector3 mousePositionVec3 = Input.mousePosition;
        mousePositionVec3.z = Camera.main.transform.position.z;

        // マウスポジションのスクリーンポジションをワールドポジションに変換
        vec = Camera.main.ScreenToWorldPoint(mousePositionVec3);

        // 三角関数をうんぬんかんぬん
        float zRotation = Mathf.Atan2(vec.y - transform.position.y, vec.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        // スピード確定
        this.rigid2D.AddForce(transform.right * speeds, ForceMode2D.Impulse);
    }
        
    
    // Update is called once per frame
    void Update()
    {
        
            


        


        // 画面の下で判定して初期化
        // 画面外に出たらという判定がほしいので先生に聞いてください。
        if (this.transform.position.y <= -15.0f || this.transform.position.y >= 15.0f || this.transform.position.x <= -10.0f || this.transform.position.x >= 10.0f)
        {
            

            // 動きを停止
            Destroy(gameObject);
            
        }
    }
}
