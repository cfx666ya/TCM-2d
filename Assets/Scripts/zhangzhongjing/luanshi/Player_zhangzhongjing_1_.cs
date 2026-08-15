using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_zhangzhongjing_1_ : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public float speed;
    public AudioSource collectionAu;

    private int collection;
    public Text collectionText;

    private int health;
    public Text healthText;

    public GameObject Chengjiu;
    public GameObject Timeline;
    public GameObject againDialog;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        collection = 0;
        health = 5;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (health == 0)
        {
            Timeline.SetActive(false);
            againDialog.SetActive(true);
        }
        anim.SetBool("Idle", true);
    }

    void Movement()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        float faced_direction = Input.GetAxisRaw("Horizontal");
        //角色移动
        rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
        anim.SetFloat("Walking", Mathf.Abs(faced_direction));
        //角色面向
        if (faced_direction != 0)
        {
            transform.localScale = new Vector3(faced_direction, 1, 1);
        }

        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        if (verticalmove != 0)
        {
            anim.SetFloat("Walking", Mathf.Abs(verticalSpeed));
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Yaofang")
        {
            collectionAu.Play();
            Destroy(collision.gameObject);
            collection++;
            collectionText.text = "得分：" + collection;
        }
        if (collision.tag == "Zhanhuo" || collision.tag == "Snake")
        {
            Destroy(collision.gameObject);
            health--;
            healthText.text = "生命：" + health;
        }
        if (collision.tag == "gateZhangzhongjing")
        {
            Time.timeScale = 0f;
            Timeline.SetActive(false);
            Chengjiu.SetActive(true);
        }
    }
}
