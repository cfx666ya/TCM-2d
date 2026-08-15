using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_zhangzhongjing_weiren_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public float speed;
    public bool is_hurt;
    public AudioSource throwAu;

    private int Player;
    public Text Player_text;

    public GameObject Again;

    // Start is called before the first frame update
    void Start()
    {
        Player = 5;
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwAu.Play();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bingren")
        {
            //用类Enemy来定义一个变量，从而获得类中的所有函数
            Bingren enemy = collision.gameObject.GetComponent<Bingren>();
            //判断血量
            if (Player > 0)
            {
                enemy.Jump_on();
                Player--;
                Player_text.text = "精力：" + Player;
            }
            else
            {
                Time.timeScale = 0f;
                Again.SetActive(true);
            }
        }
    }
}
