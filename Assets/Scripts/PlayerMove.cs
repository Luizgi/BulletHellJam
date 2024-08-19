using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Components")]
    Rigidbody2D rb2d;

    [Header("Weapons")]
    public List<GameObject> weapons;
    public List<GameObject> UIWeapons;
    private int index = 0;

    [Header("Movement")]
    public float moveSpeed;
    Vector2 moveInput;

    [Header("Dash")]
    float activeMoveSpeed;
    public float dashSpeed;
    public float DashLength = .5f, dashCooldown = 1f;
    float dashCounter;
    float dashCoolCounter;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * activeMoveSpeed;

        Dash();
        ChangeWeapon();
    }

    private void Dash()
    {
        dashSpeed = moveSpeed * 2;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = DashLength;

                Camera.main.transform.DOComplete();
                Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
                FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
            }

        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0) dashCoolCounter -= Time.deltaTime;
    }

    private void ChangeWeapon()
    {
        Vector2 scrollDelta = Input.mouseScrollDelta;
        if(scrollDelta.y != 0f)
        {
            weapons[index].SetActive(false);
            UIWeapons[index].SetActive(false);

            index += (scrollDelta.y > 0f) ? 1 : -1;

            if(index >= weapons.Count) index = 0;
            else if(index < 0) index = weapons.Count - 1;


            weapons[index].SetActive(true);
            UIWeapons[index].SetActive(true);
        }
    }
}
