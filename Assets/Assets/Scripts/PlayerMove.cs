using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Components")]
    Rigidbody2D rb2d;

    [Header("Weapons")]
    public List<GameObject> weapons;
    public List<GameObject> UIWeapons;
    private int index = 0;

    float horizontal;
    float vertical;
    float moveLimiter = .7f;

    public float runSpeed = 20f;

    [Header("Dash")]
    float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    float dashCounter;
    float dashCoolCounter;


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

        ChangeWeapon();
    }

    void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
    
        rb2d.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void ChangeWeapon()
    {
        Vector2 scrollDelta = Input.mouseScrollDelta;
        if(scrollDelta.y != 0f)
        {
            weapons[index].SetActive(false);
            UIWeapons[index].SetActive(false);

            index += (scrollDelta.y > 0f) ? 1 : -1;

            if(index >= weapons.Count)
            {
                index = 0;
            }
            else if(index < 0)
            {
                index = weapons.Count - 1;
            }

            weapons[index].SetActive(true);
            UIWeapons[index].SetActive(true);
        }
    }

}
