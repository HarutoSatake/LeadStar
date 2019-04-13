using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGround : MonoBehaviour
{
    [SerializeField]float speed = 0.0f;
    [SerializeField] bool mirror = false;
    // Start is called before the first frame update
    void Start()
    {
        if(mirror)
        {
            speed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, speed);
    }
}
