using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGenerator : MonoBehaviour
{
    [SerializeField] GameObject ClickParticle = null;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            GameObject Particle = Instantiate(ClickParticle) as GameObject;
            Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
            Particle.transform.position = Camera.main.ScreenToWorldPoint(a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
