using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon: MonoBehaviour
{
    protected GameObject position;
    protected Transform shootPos;
    protected int manyBullet;
    protected int maxBullet;
    protected Animator anim;

    [SerializeField] protected float shootSpeed;
    [SerializeField] protected GameObject gunPrefab;

    [SerializeField] protected float waitShoot;
    protected float recoilAmount;
    protected float recoilRecoveryTime;
    protected Quaternion initialRotation;
    protected ParticleSystem shellCase;
    protected float shakeIntensity;
    protected float shakeTime;

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
            GameObject gunInstance = Instantiate(gunPrefab, shootPos.transform.position, shootPos.transform.rotation);
            Vector2 shootDir = shootPos.right;
            gunInstance.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;

            shellCase.Play();
            anim.SetTrigger("recoil");
            CinemachineShake.instace.Shake(shakeIntensity, shakeTime);
    }
    protected virtual void Reload()
    {
        if(manyBullet <= 0)
        {
            manyBullet = maxBullet;
        }
    }
    public void SetBullet(TextMeshProUGUI uiBullet)
    {
        uiBullet.text = manyBullet.ToString() + " / " + maxBullet.ToString();
    }

} 