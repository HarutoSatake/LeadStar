using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleJammer : MonoBehaviour
{
    [SerializeField]
    bool Mirror = false;
    [SerializeField]
    bool X = false;
    [SerializeField]
    bool Y = false;
    [SerializeField]
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Mirror)
            speed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(X && !Y)
            transform.Translate(transform.right * speed);
        if(Y && !X)
            transform.Translate(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            speed *= -1;
        }
        
    }
}
