using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock: Weapon
{
private void Start()
    {
        position = this.gameObject;
        shootSpeed = 5f;
        waitShoot = 1f;
        shootPos = transform.Find("shootPos").transform;
    }
private void Update()
    {
        Rotate();

        waitShoot -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1"))
        {
            if(waitShoot <= 0)
            {
                Shoot();
                waitShoot = 1;
            }
        }        
    }
}
