using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Stick_Star : MonoBehaviour
{
    // 変数の定義
    Vector3 m_ini_pos = new Vector3(0, 0, 0);
    Rigidbody2D rigid2D = null;
    PositionConstraint PosCon = null;

    Vector2 vec = new Vector2(0, 0);
    private const float speeds = 20.0f;
    private bool isBulletStart = false;
    private bool isMove = false;

    [SerializeField]
    int MAXHP = 0;

    bool P_flg = false;

    private int hp = 0;

    private AudioSource s_reflect;

    [SerializeField]
    GameObject Goal = null;
    [SerializeField]
    GameObject Start_Object = null;
    [SerializeField]
    GameObject ClickParticle = null;
    [SerializeField]
    GameObject Star_Sp = null;

    public Vector3 defaultScale = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // スタートの位置に移動
        this.transform.position = Start_Object.transform.position;
        // HP設定
        hp = MAXHP;
        // リジッドボディを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.PosCon = GetComponent <PositionConstraint>();
        // 自分の座標を覚えておく(プレハブにしたらいらないかも）
        m_ini_pos = this.transform.position;

        this.defaultScale = this.transform.lossyScale;
        // 音楽の取得
        s_reflect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // スターはエンプティオブジェクトに追従するように
        // 子になるのはエンプティオブジェクト

        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Reflect")
        {
            hp--;
            // SEの再生
            s_reflect.PlayOneShot(s_reflect.clip);
        }
        if(collision.gameObject.tag == "Wall")
        {
            this.rigid2D.isKinematic = true ;
            this.rigid2D.velocity = Vector2.zero;
            this.transform.parent = collision.transform;

            Vector3 lossScale = transform.lossyScale;
            Vector3 localScale = transform.localScale;

            transform.localScale = new Vector3(
                    localScale.x / lossScale.x * defaultScale.x,
                    localScale.y / lossScale.y * defaultScale.y,
                    localScale.z / lossScale.z * defaultScale.z
            );


            this.isBulletStart = false;
            
            P_flg = true;
            // HPによって星が小さくなっていくのをしたいです
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        P_flg = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if (Input.GetMouseButtonDown(0) && !isBulletStart)
            {
                rigid2D.isKinematic = false;
                this.transform.parent = null;
                Vector3 mousePositionVec3 = Input.mousePosition;
                mousePositionVec3.z = Camera.main.transform.position.z;

                // マウスポジションのスクリーンポジションをワールドポジションに変換
                vec = Camera.main.ScreenToWorldPoint(mousePositionVec3);

                // 三角関数をうんぬんかんぬん
                float zRotation = Mathf.Atan2(vec.y - transform.position.y, vec.x - transform.position.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

                isBulletStart = true;



                // クリックしたときのエフェクト
                GameObject Particle = Instantiate(ClickParticle) as GameObject;
                Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
                Particle.transform.position = Camera.main.ScreenToWorldPoint(a);
            }
            // 速度がある場合スター画像の方を回転させる
            if (rigid2D.velocity != Vector2.zero && Star_Sp.activeSelf)
            {
                if (rigid2D.velocity.x > 0)
                    this.transform.Rotate(0, 0, -10);
                if (rigid2D.velocity.x < 0)
                    this.transform.Rotate(0, 0, 10);
            }

            // 画面の下で判定して初期化
            if (this.transform.position.y <= -15.0f || this.transform.position.y >= 15.0f || this.transform.position.x <= -10.0f || this.transform.position.x >= 10.0f || this.hp <= 0)
            {
                this.transform.position = m_ini_pos;

                hp = 0;
                // 動きを停止
                rigid2D.velocity = Vector2.zero;
                isBulletStart = false;
            }

            if (rigid2D.velocity == Vector2.zero)
            {
                isMove = false;
            }
        }
    }
    private void FixedUpdate()
    {
        // スター発射
        if(isBulletStart && !isMove)
        {
            this.rigid2D.AddForce(transform.right * speeds, ForceMode2D.Impulse);
            isMove = true;
        }
        // ゴール処理
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

    public bool GetPflg()
    {
        return P_flg;
    }

}
