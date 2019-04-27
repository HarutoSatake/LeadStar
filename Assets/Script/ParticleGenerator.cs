using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    ParticleSystem myPartcleSystem;
    private void Awake()
    {
        myPartcleSystem = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myPartcleSystem != null && myPartcleSystem.particleCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
