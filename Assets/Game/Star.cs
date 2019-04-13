using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // 変数の定義
    Vector3 m_ini_pos = new Vector3(0,0,0);
    Rigidbody2D rigid2D = null;

    Vector2 vec = new Vector2(0,0);
    private const float speeds = 20.0f;
    private bool isBulletStart =false;

    // ここ定数にしていじりたいんで先生に聞いてください
    [SerializeField] int MAXHP;
    private int hp;
    private int m_flg;

    public GameObject Goal;
    
    // Start is called before the first frame update
    void Start()
    {
        // HP設定
        hp = MAXHP;
        // リジッドボディを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        // 自分の座標を覚えておく(プレハブにしたらいらないかも）
        m_ini_pos = this.transform.position;
    }

    // トリガーエンター
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 屋根に当たったら跳ね返る処理
        //if(collision.tag == "roof")
        //{
        //    // z角度を読み取って、180度回転して返す
        //    Vector3 angle = this.transform.eulerAngles;

        //    angle.z += 180.0f;

        //    this.transform.rotation = Quaternion.Euler(angle.x, angle.y, angle.z);

        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;

        GetComponent<ParticleSystem>().Play();
        Vector3 scale = transform.localScale;
        // HPによって星が小さくなっていくのをしたいです
       
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isBulletStart)
        {
            Vector3 mousePositionVec3 = Input.mousePosition;
            mousePositionVec3.z = Camera.main.transform.position.z;

            // マウスポジションのスクリーンポジションをワールドポジションに変換
            vec = Camera.main.ScreenToWorldPoint(mousePositionVec3);

            // 三角関数をうんぬんかんぬん
            float zRotation = Mathf.Atan2(vec.y - transform.position.y, vec.x - transform.position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
            // スピード確定
            
            isBulletStart = true;

            this.rigid2D.AddForce(transform.right * speeds, ForceMode2D.Impulse);
        }

        
        // 画面の下で判定して初期化
        // 画面外に出たらという判定がほしいので先生に聞いてください。
        if (this.transform.position.y <= -15.0f || this.transform.position.y >= 15.0f || this.transform.position.x <= -10.0f || this.transform.position.x >= 10.0f || this.hp <= 0)
        {
            this.transform.position = m_ini_pos;

            hp = 0;
            // 動きを停止
            rigid2D.velocity = Vector2.zero;
            isBulletStart = false;
        }

        if (Goal.GetComponent<Goal>().GetFlg())
        {
            this.transform.position = m_ini_pos;
            rigid2D.velocity = Vector2.zero;
            isBulletStart = false;
        }
    }

    public int GetHP()
    {
        return hp;
    }
}
