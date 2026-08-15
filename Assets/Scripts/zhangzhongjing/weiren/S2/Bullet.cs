using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody2D rb;
    private AudioSource hitAu;

    void Start()
    {
        hitAu = GetComponent<AudioSource>();
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bingren enemy = hitInfo.GetComponent<Bingren>();
        if(enemy != null)
        {
            hitAu.Play();
            enemy.Jump_on();
        }
        Destroy(gameObject);
    }
}
