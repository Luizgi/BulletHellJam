using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Components")]
    Rigidbody2D rb2d;

    [Header("Weapons")]
    public Image UIGlock;
    public GameObject Glock;
    public Image UIFuzile;
    public GameObject Fuzile;
    public Image UIShotgun;
    public GameObject Shotgun;


    float horizontal;
    float vertical;
    public float runSpeed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        rb2d.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
