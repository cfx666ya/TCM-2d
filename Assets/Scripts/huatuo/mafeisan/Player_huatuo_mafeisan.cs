using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_huatuo_mafeisan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public float speed;
    public bool is_hurt;

    public GameObject Again;

    public AudioSource throwAu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            throwAu.Play();
            anim.SetTrigger("Throwing");
        }
    }
    void Movement()
    {
        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        if (verticalmove != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);
        }
    }
}
