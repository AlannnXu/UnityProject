using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform shieldPrefab;

    private Rigidbody2D rb;
    private Collider2D coll;

    [Header("移动参数")]
    public float speed = 5f;

    float xVelocity;


    [Header("投掷参数")]
    public float throwForce = 4f;

    [Header("跳跃参数")]
    public float jumpForce = 4f;

    int jumpCount;//跳跃次数

    [Header("状态")]
    public bool isOnGround;

    [Header("环境检测")]
    public LayerMask groundLayer;

    //按键设置
    bool jumpPress;
    bool shieldPress;
    bool shieldOut;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPress = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            shieldPress = true;
        }
    }

    void FixedUpdate()
    {
        isOnGroundCheck();
        Move();
        Jump();
        shieldDetect();
    }

    void shieldDetect()
    {
        if (shieldPress)
        {
            if (!shieldOut)
            {
                GameObject outShield = GameObject.FindWithTag("shield");
                outShield.transform.parent = null;
                outShield.AddComponent<Rigidbody2D>();
                outShield.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0f));
                shieldOut = true;
            }
            else
            {

                GameObject outShield = GameObject.FindWithTag("shield");
                outShield.transform.parent = transform;
                outShield.transform.position = transform.position + new Vector3(0.18f, 0, 0);
                Destroy(outShield.GetComponent<Rigidbody2D>());
                shieldOut = false;
            }
            shieldPress = false;
        }
    }

    void isOnGroundCheck()
    {
        ////判断角色碰撞器与地面图层发生接触
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer)) 
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void Move()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        //镜面翻转
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(0.4f * xVelocity, 1, 1);
        }
    }

    void Jump()
    {
        //在地面上
        if (isOnGround)
        {
            jumpCount = 1;
        }
        //在地面上跳跃
        if (jumpPress && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPress = false;
        }
        //在空中跳跃
        else if (jumpPress && jumpCount > 0 && !isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPress = false;
        }
    }
}

