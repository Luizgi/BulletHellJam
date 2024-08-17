using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [Header("Components")]
    protected ParticleSystem ps_blood;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer spr;
    protected BoxCollider2D bc;


    [Header("Others")]
    protected float timeDestroy;
    protected int life;
    protected Color original;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            LostLife();
            Destroy(collision.gameObject);
        }
    }

    private void LostLife()
    {
        StartCoroutine(FlashWhite());
        life--;

        if (life <= 0) Die();
    }

    private void Die()
    {
        ps_blood.Play();
        spr.sprite = null;
        bc.enabled = false;

        Destroy(this.gameObject, timeDestroy);
    }

    IEnumerator FlashWhite()
    {
        spr.color = Color.white;
        yield return new WaitForSeconds(.1f);
        spr.color = original;
    }
}
