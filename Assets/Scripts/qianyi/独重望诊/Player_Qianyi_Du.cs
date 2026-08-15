using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Qianyi_Du : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    public AudioSource collectionAu;
    private int count;

    [Header("确认")]
    public GameObject dialogAlwaysWrong;
    public GameObject dialogXin;
    public GameObject dialogGan;
    public GameObject dialogPi;
    public GameObject dialogFei;
    public GameObject dialogShen;

    [Header("自己")]
    public GameObject Myself;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (count == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Movement()
    {
        //左右方向的移动
        float horizontalmove; //正负表示方向
        horizontalmove = Input.GetAxis("Horizontal");
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }

        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        if (verticalmove != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Xin")
        {
            if(Myself.tag == "PlayerXin")
            {
                dialogXin.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                dialogAlwaysWrong.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (collision.tag == "Gan")
        {
            if (Myself.tag == "PlayerGan")
            {
                dialogGan.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                dialogAlwaysWrong.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (collision.tag == "Pi")
        {
            if (Myself.tag == "PlayerPi")
            {
                dialogPi.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                dialogAlwaysWrong.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (collision.tag == "Fei")
        {
            if (Myself.tag == "PlayerFei")
            {
                dialogFei.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                dialogAlwaysWrong.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (collision.tag == "Shen")
        {
            if (Myself.tag == "PlayerShen")
            {
                dialogShen.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                dialogAlwaysWrong.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
