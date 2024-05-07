using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fuzile : Weapon
{
    [SerializeField] TextMeshProUGUI uiBullet;
    private void Start()
    {
        SetBullet(uiBullet);

        position = this.gameObject;



        shootSpeed = 10f;
        waitShoot = .1f;
        maxBullet = 60;
 
        shootPos = transform.Find("shootPos").transform;
        manyBullet = maxBullet;

    }
    private void Update()
    {
        SetBullet(uiBullet);
        Rotate();

        if (Input.GetKeyDown(KeyCode.R))
        {
            base.Reload();
        }

        waitShoot -= Time.deltaTime;
        if (Input.GetButton("Fire1") && manyBullet > 0)
        {
            if (waitShoot <= 0)
            {
                Shoot();
     

                waitShoot = .1f;
                manyBullet -= 1;
            }
        }
    }
}
