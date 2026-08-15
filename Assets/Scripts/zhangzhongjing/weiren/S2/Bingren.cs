using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingren : MonoBehaviour
{
    protected AudioSource deathAu;

    protected virtual void Start()
    {
        deathAu = GetComponent<AudioSource>();
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    //定义为public，可以让其他代码调用
    public void Jump_on()
    {
        deathAu.Play();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject);
    }
}
