using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafeisan : MonoBehaviour
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
        Bingren_Move enemy = hitInfo.GetComponent<Bingren_Move>();
        if (enemy != null)
        {
            hitAu.Play();
            enemy.Slowdown();
        }
        Destroy(gameObject);
    }
}
