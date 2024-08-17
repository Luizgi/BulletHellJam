using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : Enemies
{

    [Header("IA Constraints")]
    Transform playerTransform;
    float speed = 3f;
    float detectionRadius = 5f;

    private void Awake()
    {
        playerTransform = FindAnyObjectByType<PlayerMove>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, playerTransform.position) <= detectionRadius)
        {
            Vector3 dir = (playerTransform.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
