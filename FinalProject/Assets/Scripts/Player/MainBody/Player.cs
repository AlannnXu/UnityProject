using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [Header("身体部分")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform shieldPrefab;
    [SerializeField] private Transform rightHandPrefab;
    [SerializeField] private Transform leftHandPrefab;

    [SerializeField] private Transform buleTimeBall;
    [SerializeField] private Transform thunderBall;
    [SerializeField] private ThunderBall thunderBallScript;

    [SerializeField] private platformMove platformScript;
    [SerializeField] private Buttons buttonScript;
    [SerializeField] private Buttons buttonScript2;

    // 物理材料
    public PhysicsMaterial2D p1;    // 有摩擦力的
    public PhysicsMaterial2D p2;    // 无摩擦力的
    public int keyNum;
    public Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;

    [Header("音效")]
    public AudioSource RunSound;
    public AudioSource jumpSound;


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
    public float jumpForce = 6f;
    public float superJumpForce = 8f;

    public int jumpCount;//跳跃次数

    [Header("状态")]
    public bool isOnGround;
    public bool isOnButton;
    private bool isRunning = false;
    public bool isDead;
    [Header("环境检测")]
    public LayerMask groundLayer;
    public LayerMask buttonLayer;

    //按键设置
    [SerializeField] bool jumpPress;
    bool shieldPress;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        shieldPrefab.GetComponent<Collider2D>().enabled = false;
        haveShield = true;
        animator.Update(0f);
        animator.Play("0_idle");
        keyNum = 0;
        rb.sharedMaterial = p1;
        if (status > 1) {
            speed = 4f;
            jumpForce = 6f;
        } else {
            speed = 3f;
            jumpForce = 6f;
        }
    }


    void Update()
    {
        if (!isDead) {
            if (Input.GetButtonDown("Jump"))
            {
                jumpPress = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                shieldPress = true;
            }
            if (status >= 2 && Input.GetKeyDown(KeyCode.K)) {
                if (GameObject.FindWithTag("blueTimeBall") == null)
                    Instantiate(buleTimeBall, transform.position, transform.rotation);
            }
            if (status >= 4 && Input.GetKeyDown(KeyCode.L)) {
                if (GameObject.FindWithTag("thunderBall") == null) {
                    Instantiate(thunderBall, rightHandPrefab.position + Vector3.up * 0.2f + Vector3.right * 1.1f, transform.rotation);
                    thunderBallScript = GameObject.FindWithTag("thunderBall").GetComponent<ThunderBall>();
                    thunderBallScript.direction = -transform.localScale.x;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead) {
            isOnGroundCheck();
            isOnButtonCheck();
            Move();
            Jump();
            if (haveShield)
            {
                shieldDetect();
            } else {
                isShieldOnGroundCheck();
            }
        } else {
            rb.velocity = Vector2.zero;
        }

        
    }

    void shieldDetect()
    {
        if (shieldPress && !isDead)
        {
            if (!shieldOut)
            {
                haveShield = false;
                GameObject outShield = GameObject.FindWithTag("shield");
                outShield.transform.parent = null;
                outShield.AddComponent<Rigidbody2D>();
                outShield.GetComponent<Rigidbody2D>().mass = 100;
                if (transform.localScale.x > 0) {
                    outShield.GetComponent<Rigidbody2D>().velocity = new Vector2(-throwForce,outShield.GetComponent<Rigidbody2D>().velocity.y);
                } else {
                    outShield.GetComponent<Rigidbody2D>().velocity = new Vector2(throwForce,outShield.GetComponent<Rigidbody2D>().velocity.y);
                }
                
                outShield.GetComponent<Collider2D>().enabled = true;
                outShield.GetComponent<Collider2D>().isTrigger = true;
                status--;
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
            rb.sharedMaterial = p1;
        }
        else
        {
            isOnGround = false;
            rb.sharedMaterial = p2;
        }

   
    }
        void isOnButtonCheck()
    {
        ////判断角色碰撞器与button图层发生接触
        GameObject outShield = GameObject.FindWithTag("shield");
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, buttonLayer) || Physics2D.OverlapCircle(outShield.transform.position, 0.4f, buttonLayer)) 
        {
            if (buttonScript != null) {
                buttonScript.isOnButton = true;
            } 
            if ((!Physics2D.OverlapCircle(groundCheck.position, 0.1f, buttonLayer)) && Physics2D.OverlapCircle(outShield.transform.position, 0.4f, buttonLayer) && shieldOut) {
                if (buttonScript != null) {
                    if (buttonScript2 != null) {
                        if (buttonScript2 != buttonScript) {
                            if (buttonScript.isOnButton) {
                                buttonScript.isNeedToIncrease = true; 
                            }
                            buttonScript.isOnButton = false;
                        }
                        
                    } else {
                        if (buttonScript.isOnButton) {
                            
                            buttonScript2 = buttonScript;
                        } 
                    }
                   
                    
                }
                
            }

            

        }
        else
        {

            if (buttonScript != null) {
                
                if (buttonScript.isOnButton) {
                    buttonScript.isNeedToIncrease = true; 
                }
                buttonScript.isOnButton = false;
            }             
            isOnButton = false;

        }
        if (!Physics2D.OverlapCircle(outShield.transform.position, 0.4f, buttonLayer)) {
            buttonScript2 = null;
        }
   
    }

    void isShieldOnGroundCheck()
    {
        ////判断盾牌碰撞器与地面图层发生接触
        GameObject outShield = GameObject.FindWithTag("shield");
        if (Physics2D.OverlapCircle(outShield.transform.position, 1f, groundLayer)) 
        {
            shieldOut = true;

            outShield.GetComponent<Collider2D>().isTrigger = false;
        }  
    }

    void Move()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        //镜面翻转
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(1.0f * (-xVelocity), 1.0f, 1);
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isOnGround &&isRunning)
        {
            if (!RunSound.isPlaying)
            {
                RunSound.Play();
            }
        }
        else
        {
            RunSound.Stop();
        }

        
    }

    void Jump()
    {
        // //在地面上
        // if (isOnGround)
        // {
        //     jumpCount = 0;
        // }
        //在地面上跳跃
        if (jumpPress && isOnGround)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // jumpCount = 1;
            jumpPress = false;
        }
        else if (jumpPress && !isOnGround) {
            jumpPress = false;
        }
        // //在空中跳跃
        // else if (jumpPress && jumpCount > 0 && !isOnGround)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     jumpCount = 0;
        //     jumpPress = false;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (shieldOut && other.gameObject.tag == "shield") {

            other.transform.parent = leftHandPrefab;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            Destroy(other.transform.GetComponent<Rigidbody2D>());
            other.transform.GetComponent<Collider2D>().enabled = false;
            shieldOut = false;
            haveShield = true;
            status++;
        } else if (other.gameObject.tag == "blockDoor" && keyNum > 0) {
            keyNum--;
            Destroy(other.gameObject);
        } 
        // else if (other.gameObject.tag == "platform") {
        //     platformScript = other.gameObject.GetComponent<platformMove>();
        //     if (platformScript.flag) {
        //         Debug.Log("ssdczx");
        //         transform.position = new Vector3(transform.position.x + platformScript.directionOfPlatform * platformScript.speed * Time.deltaTime * 2f,
        //         transform.position.y, transform.position.z);
        //     }
        // }
    }

    public void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "platform") {
            platformScript = other.gameObject.GetComponent<platformMove>();
            if (platformScript.flag && !platformScript.isInBlue) {

                transform.position = new Vector3(transform.position.x + platformScript.directionOfPlatform * platformScript.speed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            }
        } else if (other.gameObject.tag == "thunderBall") {
            if (!thunderBallScript.isInBlue) {
                Debug.Log("on ball");
                // transform.position = new Vector3(transform.position.x + thunderBallScript.direction * thunderBallScript.speed * Time.deltaTime,
                //     transform.position.y, transform.position.z);
                rb.MovePosition(rb.position + thunderBallScript.direction * new Vector2(thunderBallScript.speed, 0) * Time.deltaTime);
            }
        } else if (other.gameObject.tag == "button") {

            buttonScript = other.gameObject.GetComponent<Buttons>();
            if (buttonScript.correspondingBlockDoor != null && !buttonScript.isInBlue && !buttonScript.isInBlue2) {
                if (!buttonScript.flag1) {
                    buttonScript.correspondingBlockDoor.position = new Vector3(buttonScript.correspondingBlockDoor.position.x, 
                        buttonScript.correspondingBlockDoor.position.y - buttonScript.DoorSpeed * Time.deltaTime, buttonScript.correspondingBlockDoor.position.z);
                } else {
                    buttonScript.correspondingBlockDoor.position = new Vector3(buttonScript.correspondingBlockDoor.position.x + buttonScript.DoorSpeed * Time.deltaTime, 
                        buttonScript.correspondingBlockDoor.position.y, buttonScript.correspondingBlockDoor.position.z);                    
                }

                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 
                    other.gameObject.transform.position.y - buttonScript.buttonSpeed * Time.deltaTime, other.gameObject.transform.position.z);         
                buttonScript.forceStop = false;
            }
            if (buttonScript.correspondingBlockDoor2 != null && !buttonScript.isInBlue && !buttonScript.isInBlue2) {
                if (!buttonScript.flag2) {
                    buttonScript.correspondingBlockDoor2.position = new Vector3(buttonScript.correspondingBlockDoor2.position.x,
                        buttonScript.correspondingBlockDoor2.position.y - buttonScript.DoorSpeed * Time.deltaTime, buttonScript.correspondingBlockDoor2.position.z);
                } else {
                    buttonScript.correspondingBlockDoor2.position = new Vector3(buttonScript.correspondingBlockDoor2.position.x + buttonScript.DoorSpeed * Time.deltaTime,
                        buttonScript.correspondingBlockDoor2.position.y, buttonScript.correspondingBlockDoor2.position.z);                    
                }


            }

        }     
    }


    void OnTriggerEnter2D(Collider2D other)//接触时触发，无需调用
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);

        switch (other.gameObject.tag) {
            case "EnemyHead":
                if (status % 2 == 1) {
                    rb.velocity = new Vector2(rb.velocity.x, superJumpForce);
                    //Destroy(other.transform.parent.gameObject);
                    other.transform.parent.GetChild(1).gameObject.GetComponent<Animator>().Play("4_Death");
                } else {
                    PlayerDeath();
                }

                break;
            case "EnemyBody":
                PlayerDeath();
                break;
            case "hazard":
                PlayerDeath();
                break;
            case "Key":
                keyNum++;
                Destroy(other.gameObject);
                break;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "Finish":
                PlayerDeath();
                break;
        }
    }

    public void PlayerDeath() {
        isDead = true;
        animator.Play("4_Death 1");
        
        Invoke("Reload", 1f);        
    }

    private void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

