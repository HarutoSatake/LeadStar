using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

    private Vector2 lastVelocity = new Vector2(0,0);
    private Rigidbody2D rb = null   ;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal);
        this.rb.velocity = refrectVec;
    }
}
