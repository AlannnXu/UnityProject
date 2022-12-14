using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float dis;
    [SerializeField] private Transform groundCheck;
    //移动速度
    public float speed;
    //水平移动为true 竖直移动为false
    public bool flag = true;
    //移动方向

    [Header("状态")]
    public bool isOnGround;
    public LayerMask groundLayer;
    float dir = 1;
    Vector3 startPos;
    public Vector3 endPos;
    Vector3 beforePos;
    Vector3 afterPos;
    //起始位置
    float start_x;
    float start_y;

    void Start()
    {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1);
        dir = -1;
        start_x = transform.position.x;//水平移动的起点
        start_y = transform.position.y;//竖直移动的起点
        m_Rigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        if (flag) {
            endPos = new Vector3(transform.position.x + dis, transform.position.y, transform.position.z);
        } else {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + dis);
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

    private void FixedUpdate() {
        
        if (flag) {
            isOnGroundCheck();
            m_Rigidbody.MovePosition(transform.GetComponent<Rigidbody2D>().position + dir * Time.fixedDeltaTime * new Vector2(speed, 0));
            // m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, dis) * dir * new Vector3(1, 0, 0) + startPos);
            if (dir == 1 && Vector3.Distance(endPos, transform.position) < 0.01f) {
                dir = - dir;
                transform.localScale = new Vector3(1.0f, 1.0f, 1);
            } else if (dir == -1 && Vector3.Distance(transform.position, startPos) < 0.01f) {
                dir = - dir;
                transform.localScale = new Vector3(-1.0f, 1.0f, 1);
            }
            if (!isOnGround) {
                dir = - dir;
                transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1);

            }
            
        } else {
            m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, dis) * dir * new Vector3(0, 1, 0) + startPos);
            if (Vector3.Distance(endPos, transform.position) < 0.01f) {
                transform.localScale = new Vector3(1.0f, 1.0f, 1);
            } else if (Vector3.Distance(transform.position, startPos) < 0.01f) {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "shield" || other.transform.tag == "blockDoor") {
            
            
            dir = - dir;
            transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1);
        }         
    }


}

