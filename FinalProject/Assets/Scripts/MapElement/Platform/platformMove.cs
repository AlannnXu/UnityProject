using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float dis;
    //移动速度
    public float speed;
    public bool isInBlue;
    //水平移动为true 竖直移动为false
    public bool flag = true;
    //移动方向
    public float directionOfPlatform = 1;
    Vector3 startPos;
    Vector3 endPos;
    //起始位置
    float start_x;
    float start_y;

    void Start()
    {
        directionOfPlatform = -1;
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



    private void FixedUpdate() {
        if (!isInBlue) {
            if (flag) {
                
                m_Rigidbody.MovePosition(transform.GetComponent<Rigidbody2D>().position + directionOfPlatform * Time.fixedDeltaTime * new Vector2(speed, 0));
                // m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, dis) * directionOfPlatform * new Vector3(1, 0, 0) + startPos);
                if (directionOfPlatform == 1 && Vector3.Distance(endPos, transform.position) < 0.01f) {
                    directionOfPlatform = - directionOfPlatform;
                    
                } else if (directionOfPlatform == -1 && Vector3.Distance(transform.position, startPos) < 0.01f) {
                    directionOfPlatform = - directionOfPlatform;
                    
                }

                
            } else {
                m_Rigidbody.MovePosition(Mathf.PingPong(Time.time * speed, dis) * directionOfPlatform * new Vector3(0, 1, 0) + startPos);
                if (directionOfPlatform == 1 && Vector3.Distance(endPos, transform.position) < 0.01f) {
                    directionOfPlatform = - directionOfPlatform;
                    
                } else if (directionOfPlatform == -1 && Vector3.Distance(transform.position, startPos) < 0.01f) {
                    directionOfPlatform = - directionOfPlatform;
                    
                }
            } 
        }
       
        
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