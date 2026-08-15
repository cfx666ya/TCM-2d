using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_sunsimiao_yaoji : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    public AudioSource collectionAu;

    private int collection;
    public Text collectionText;

    public GameObject Chengjiu;
    public GameObject Timeline;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        collection = 0;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(collection == 30)
        {
            Time.timeScale = 0f;
            Chengjiu.SetActive(true);
            Timeline.SetActive(false);
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
    }
}
