using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)//接触时触发，无需调用
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
        if (other.gameObject.tag == "Player") {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
}
