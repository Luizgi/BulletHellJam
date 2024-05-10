using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        ps_blood = this.GetComponentInChildren<ParticleSystem>();
        rb2d = this.GetComponent<Rigidbody2D>();
        spr = this.GetComponentInChildren<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        original = this.spr.color;

        timeDestroy = ps_blood.main.duration;

        life = 5;
    }
}
