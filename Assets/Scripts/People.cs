using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform left_point, right_point;
    private float left_x, right_x;
    public bool faced_left;//用来判断幽灵的面向

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();//在游戏开始，获得左右孩子点的那一刻，断绝父子关系

        //将左右两点的值赋给变量后，销毁这两个物体，防止堆积
        left_x = left_point.position.x;
        right_x = right_point.position.x;
        Destroy(left_point.gameObject);
        Destroy(right_point.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (faced_left)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < left_x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faced_left = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > right_x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faced_left = true;
            }
        }
    }
}
