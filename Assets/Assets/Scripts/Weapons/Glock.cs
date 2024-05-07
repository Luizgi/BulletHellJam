using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Glock: Weapon
{
    [SerializeField] TextMeshProUGUI uiBullet;

    private void Start()
    {
        SetBullet(uiBullet);
        SetBullet(uiBullet);

        position = this.gameObject;
        shootSpeed = 5f;
        waitShoot = .5f;
        maxBullet = 12;
        shootPos = transform.Find("shootPos").transform;
        manyBullet = maxBullet;
    }
    private void Update()
    {
        Rotate();
        SetBullet(uiBullet);

        if (Input.GetKeyDown(KeyCode.R))
        {
            base.Reload();
        }

        waitShoot -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && manyBullet > 0)
        {
            if(waitShoot <= 0)
            {
                Shoot();
                waitShoot = .5f;
                manyBullet -= 1;
            }
        }        
    }
}
