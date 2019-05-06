using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyObj : MonoBehaviour
{
    // NoDestroyObjインスタンスの実体
    private static NoDestroyObj instance = null;
    // BGMを消すかどうか
    private bool DesFlg = false;
    // NoDestroyObjインスタンスのプロパティーは、実体が存在しないとき（＝初回参照時）実体を探して登録する
    public static NoDestroyObj Instance => instance
        ?? (instance = GameObject.FindWithTag("GameController").GetComponent<NoDestroyObj>());

    private void Awake()
    {
        // もしインスタンスが複数存在する、もしくは削除を指示された場合オブジェクトを破棄する
        if (this != Instance || DesFlg)
        {
            Destroy(this.gameObject);
            return;
        }

        // 唯一のインスタンスなら、シーン遷移しても残す
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDestroy()
    {
        // 破棄時に、登録した実体の解除を行う
        if (this == Instance) instance = null;
    }

    // 
    public void SetDestroy(bool _set)
    {
        this.DesFlg = _set;
    }
}
