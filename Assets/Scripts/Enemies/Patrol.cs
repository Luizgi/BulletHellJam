using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemies
{

    [Header("IA Coinstraints")]
    public Transform[] waypoints;
    float speed = 2f;
    int currentWaypoint = 0;
    float waypointThreshold = .1f;

    // Start is called before the first frame update
    void Start()
    {
        //Gettin My Components
        ps_blood = this.GetComponentInChildren<ParticleSystem>();
        rb2d = this.GetComponent<Rigidbody2D>();
        spr = this.GetComponentInChildren<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        original = this.spr.color;


        timeDestroy = ps_blood.main.duration;
        life = 5;
    }

    private void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypoint];
        Vector3 dir = (target.position - transform.position);
        transform.position += dir * speed * Time.deltaTime;

        if(Vector2.Distance(transform.position, target.position) < waypointThreshold) currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}
