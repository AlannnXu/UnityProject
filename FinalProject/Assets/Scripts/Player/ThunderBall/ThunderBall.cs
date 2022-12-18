using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThunderBall : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public TextMeshProUGUI countDownText;
    private float count = 4f;
    // public Transform player;
    public EnemyMove enemyScript;
    public float speed = 10f;
    public float direction = 1;
    public bool isInBlue;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        // direction = player.localScale.x;
    }

    void Update()
    {
        if (!isInBlue) {
            count -= Time.deltaTime;
        } else {
            count -= Time.deltaTime / 20;
        }
        
        countDownText.text = Mathf.Floor(count).ToString();
        if (Mathf.Floor(count) == 0) {
            DestroyThunderBall();
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isInBlue){
            m_Rigidbody.MovePosition(m_Rigidbody.position + direction * Time.fixedDeltaTime *  new Vector2(speed, 0));
        } else {
            m_Rigidbody.MovePosition(m_Rigidbody.position + direction * Time.fixedDeltaTime *  new Vector2(speed / 20, 0));
        }

        if (Physics2D.OverlapCircle(transform.position, 0.3f, groundLayer)) 
        {
            DestroyThunderBall();
        }
            
    }

    void isOnGroundCheck()
    {


   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // switch (other.gameObject.tag) {

        // }
        Debug.Log(Time.time + ":进入thunder ball collision的对象是：" + other.gameObject.name);
        if (other.gameObject.tag != "Player") {
            DestroyThunderBall();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        Debug.Log(Time.time + ":离开thunder ball collision的对象是：" + other.gameObject.name);
        // switch (other.gameObject.tag) {

        // }        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(Time.time + ":进入thunder ball trigger的对象是：" + other.gameObject.name);
        switch (other.gameObject.tag) {
            case "EnemyHead":
                enemyScript = other.gameObject.transform.parent.gameObject.GetComponent<EnemyMove>();
                enemyScript.enemyDeath();
                break;            
            case "EnemyBody":
                enemyScript = other.gameObject.GetComponent<EnemyMove>();
                enemyScript.enemyDeath();
                break;
            case "blueTimeBall":
                isInBlue = true;
                break;
        }
        if (other.gameObject.tag != "blueTimeBall" && other.gameObject.tag != "Key" && other.gameObject.tag != "Finish")
            DestroyThunderBall();     
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "Finish":
                Destroy(transform.gameObject);
                break;
            case "blueTimeBall":
                isInBlue = false;
                break;
        }
    }

    public void DestroyThunderBall() {
        Destroy(transform.gameObject);
    }
}
