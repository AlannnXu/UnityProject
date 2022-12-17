using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float dis;
    // public Transform begin;
    // public Transform end;
    //移动速度
    public float speed;
    //水平移动为true 竖直移动为false
    public bool flag = true;
    //移动方向
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

    // public void Move()
    // {
    //     //移动
    //     //竖直移动
    //     if (flag)
    //     {
    //         transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
    //         if (System.Math.Abs(transform.position.x - start_x) <= 0.1f || System.Math.Abs(transform.position.x - start_x) >= dis) { dir = -dir; }
    //     }
    //     //水平移动
    //     else {
    //         transform.Translate(Vector2.up * dir * speed * Time.deltaTime);
    //         if (System.Math.Abs(transform.position.y - start_y) <= 0.1f || System.Math.Abs(transform.position.y - start_y) >= dis) { dir = -dir; }
    //     }
    // }

    private void FixedUpdate() {
        // if (flag) {
        //     m_Rigidbody.MovePosition(transform.position + Vector3.right * dir * speed * Time.deltaTime);
        // } else {
        //     m_Rigidbody.MovePosition(transform.position + Vector3.up * dir * speed * Time.deltaTime);
        // }

        // if (flag) {
        //     m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, ))
        // }
        if (flag) {
            
            m_Rigidbody.MovePosition(transform.GetComponent<Rigidbody2D>().position + dir * Time.fixedDeltaTime * new Vector2(speed, 0));
            // m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, dis) * dir * new Vector3(1, 0, 0) + startPos);
            if (dir == 1 && Vector3.Distance(endPos, transform.position) < 0.01f) {
                dir = - dir;
                transform.localScale = new Vector3(1.0f, 1.0f, 1);
            } else if (dir == -1 && Vector3.Distance(transform.position, startPos) < 0.01f) {
                dir = - dir;
                transform.localScale = new Vector3(-1.0f, 1.0f, 1);
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
        if (other.transform.tag == "shield") {
            Debug.Log("s");
            
            dir = - dir;
            transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1);
        }         
    }

    public void enemyDeath() {
        Debug.Log("ddd");
        Destroy(transform.gameObject);
    }


}
// public class MovingPlatform : MonoBehaviour
// {
//  public float speed;
//  public Transform start;
//  public Transform end;
 
//  private Vector3 startPos;
//  private Vector3 endPos;
//  private float distance;
//  private Vector3 direction;
 
//  private Rigidbody2D rb;
 
 
//  public void Awake()
//  {
//   rb = GetComponent<Rigidbody2D>();
//   rb.isKinematic = true;
//   startPos = start.position;
//   endPos = end.position;
//   distance = Vector3.Distance(endPos, startPos);
//   direction = Vector3.Normalize(endPos - startPos);
//  }
 
//  public void FixedUpdate ()
//  {
//   rb.MovePosition(Mathf.PingPong(Time.time*speed, distance)*direction + startPos);
//  }
// }
