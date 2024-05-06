using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    [SerializeField]protected GameObject position;
    [SerializeField]protected float shootSpeed;
    [SerializeField]protected GameObject gun;
    [SerializeField]protected Transform shootPos; 
    [SerializeField]protected float waitShoot;

    // Update is called once per frame

    protected void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objPos = Camera.main.WorldToScreenPoint(position.transform.position);

        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;

        float ang = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        position.transform.rotation = Quaternion.Euler(new Vector3(0, 0, ang));
    }

    protected void Shoot()
    {       
                gun = Instantiate(gun, shootPos.transform.position, shootPos.transform.rotation);
                Vector2 shootDir = shootPos.right;
                gun.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
    }
    protected void Recoil()
    {

    }
}
