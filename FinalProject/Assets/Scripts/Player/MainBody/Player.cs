using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform shieldPrefab;
    [SerializeField] private Transform rightHandPrefab;
    public Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;

    [Header("移动参数")]
    public float speed = 5f;

    float xVelocity;

    [Header("人物形态")]
    [SerializeField] bool haveShield = true;

    // 0-normal person;
    // 1-with shield;
    // 2-have time slower;
    // 3-exploding flash;
    public int status = 1;

    [Header("投掷参数")]
    public float throwForce = 4f;
    [SerializeField] bool shieldOut;

    [Header("跳跃参数")]
    public float jumpForce = 4f;

    public int jumpCount;//跳跃次数

    [Header("状态")]
    public bool isOnGround;
    private bool isRunning = false;
    [Header("环境检测")]
    public LayerMask groundLayer;

    //按键设置
    bool jumpPress;
    bool shieldPress;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        shieldPrefab.GetComponent<Collider2D>().enabled = false;
        haveShield = true;
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPress = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            shieldPress = true;
        }
    }

    void FixedUpdate()
    {
        isOnGroundCheck();
        Move();
        Jump();
        if (haveShield)
        {
            shieldDetect();
        } else {
            isShieldOnGroundCheck();
        }
        
    }

    void shieldDetect()
    {
        if (shieldPress)
        {
            if (!shieldOut)
            {
                haveShield = false;
                GameObject outShield = GameObject.FindWithTag("shield");
                outShield.transform.parent = null;
                outShield.AddComponent<Rigidbody2D>();
                outShield.GetComponent<Rigidbody2D>().velocity = new Vector2(throwForce,outShield.GetComponent<Rigidbody2D>().velocity.y);
                outShield.GetComponent<Collider2D>().enabled = true;
                outShield.GetComponent<Collider2D>().isTrigger = true;
                // shieldOut = true;
            }
            // else
            // {
            //     haveShield = true;
            //     GameObject outShield = GameObject.FindWithTag("shield");
            //     outShield.transform.parent = rightHandPrefab;
            //     outShield.transform.localPosition = Vector3.zero;
            //     Destroy(outShield.GetComponent<Rigidbody2D>());
            //     outShield.GetComponent<Collider2D>().enabled = false;
            //     shieldOut = false;
            // }
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

    void isShieldOnGroundCheck()
    {
        ////判断盾牌碰撞器与地面图层发生接触
        GameObject outShield = GameObject.FindWithTag("shield");
        if (Physics2D.OverlapCircle(outShield.transform.position, 1f, groundLayer)) 
        {
            shieldOut = true;
            Debug.Log("sss");
            outShield.GetComponent<Collider2D>().isTrigger = false;
        }
        // else
        // {
        //     shieldOut = false;
        // }     

   
    }

    void Move()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        //镜面翻转
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(1.0f * (-xVelocity), 1.0f, 1);
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (shieldOut && other.gameObject.tag == "shield") {
            Debug.Log("ggd");
            other.transform.parent = rightHandPrefab;
            other.transform.localPosition = Vector3.zero;
            Destroy(other.transform.GetComponent<Rigidbody2D>());
            other.transform.GetComponent<Collider2D>().enabled = false;
            shieldOut = false;
            haveShield = true;
        }        
    }

    void OnTriggerEnter2D(Collider2D other)//接触时触发，无需调用
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
        // if (shieldOut && other.gameObject.tag == "shield") {
        //     other.transform.parent = rightHandPrefab;
        //     other.transform.localPosition = Vector3.zero;
        //     Destroy(other.GetComponent<Rigidbody2D>());
        //     other.GetComponent<Collider2D>().enabled = false;
        //     shieldOut = false;
        // }
        switch (other.gameObject.tag) {
            case "EnemyHead":
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Destroy(other.transform.parent.gameObject);
                break;
            case "EnemyBody":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            // case "shield":
            //     other.transform.parent = transform;

            //     break;
        }

        
    }
}

