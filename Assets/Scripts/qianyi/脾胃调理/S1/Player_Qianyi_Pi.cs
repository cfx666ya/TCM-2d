using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Qianyi_Pi : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    private Animator anim;


    [Header("对话框")]
    public GameObject dialogWrong;
    public GameObject dialogRight;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
        if (collision.tag == "Wrong")
        {
            dialogWrong.SetActive(true);
            Time.timeScale = 0f;
        }
        if (collision.tag == "Baishusanmo")
        {
            dialogRight.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
