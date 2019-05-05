using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    bool clearflg = false;

    private AudioSource s_goal = null;
    // Start is called before the first frame update
    void Start()
    {
        s_goal = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            // スターのオブジェクトを非アクティブ化
            GameObject Star_sp = GameObject.Find("Star");
            Star_sp.SetActive(false);
            //s_goal.PlayOneShot(s_goal.clip);
            clearflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetFlg()
    {
        return clearflg;
    }
}
