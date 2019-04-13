using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    [SerializeField]
    GameObject Level1 = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // レベル毎にページ用意して動かせるといいなあって
        Level1.transform.Translate(1.0f, 0.0f, 0.0f);
        
    }
}
