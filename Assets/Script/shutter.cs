using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shutter : MonoBehaviour
{
    // シャッタースクリプト
    // 開閉時間を設定(同じにしてもおｋ)
    [SerializeField]
    private float shut_time = 0.0f;
    [SerializeField]
    private float open_time = 0.0f;
    // 時間調整
    [SerializeField]
    private float start_time = 0.0f;
    private float count = 0;
    // 開閉スピード
    private const float speed = 0.5f;
    // 開閉時の各大きさの設定
    [SerializeField]
    private float MAX_SCALE_Y = 0.0f;
    private float MIN_SCALE_Y = 1.0f;
    // あいてるかあいてないか
    enum State
    {
        OPEN,
        OPENING,
        CLOSE,
        CLOSING
    };

    private State state = State.OPEN;
    // Start is called before the first frame update
    void Start()
    {
        if (start_time > 180)
            start_time = 180;

        count = start_time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            switch (state)
            {
                case State.OPEN:
                    // 時間まで静止
                    if (count >= open_time)
                    {
                        count = 0;
                        state = State.CLOSING;
                    }
                    count += Time.deltaTime;
                    break;
                case State.OPENING:

                    Vector3 scale = transform.localScale;
                    // 最低になるまで加算
                    if (scale.y > MIN_SCALE_Y)
                    {
                        scale = new Vector3(scale.x, scale.y - speed, scale.z);
                        //transform.Translate(Vector2.up * speed / 2);
                        transform.Translate(0, speed / 2, 0);
                        transform.localScale = scale;
                    }
                    if (scale.y <= MIN_SCALE_Y)
                    {
                        state = State.OPEN;
                    }
                    break;
                case State.CLOSE:
                    // 時間まで静止
                    if (count >= shut_time)
                    {
                        count = 0;
                        state = State.OPENING;
                    }
                    count += Time.deltaTime;
                    break;
                case State.CLOSING:
                    scale = transform.localScale;

                    // 最大になるまで加算
                    if (scale.y < MAX_SCALE_Y)
                    {
                        scale = new Vector3(scale.x, scale.y + speed, scale.z);
                        transform.Translate(0, (speed / 2) * -1, 0);
                        transform.localScale = scale;
                    }
                    if (scale.y >= MAX_SCALE_Y)
                    {
                        state = State.CLOSE;
                    }

                    break;
                default:
                    Debug.Log("このメッセージが出るのはおかしいよ！");
                    break;
            }
            // カウントで開閉時間をループさせる

            // カウント増加
            count++;
        }
    }
}
