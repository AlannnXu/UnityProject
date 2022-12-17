using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 4f;
    public Animator enemyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)//接触时触发，无需调用
     {
         
        if (other.gameObject.tag == "Player") {
             
             enemyAnimation.Play("4_Death");
         }
        
     }
}
