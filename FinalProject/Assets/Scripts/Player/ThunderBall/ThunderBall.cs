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
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        // direction = player.localScale.x;
    }

    void Update()
    {
        count -= Time.deltaTime;
        countDownText.text = Mathf.Floor(count).ToString();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isInBlue){
            m_Rigidbody.MovePosition(m_Rigidbody.position + direction * Time.fixedDeltaTime *  new Vector2(speed, 0));
        } else {
            m_Rigidbody.MovePosition(m_Rigidbody.position + direction * Time.fixedDeltaTime *  new Vector2(speed / 20, 0));
        }
            
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(Time.time + ":进入thunderBall触发器的对象是：" + other.gameObject.name);
        switch (other.gameObject.tag) {
            case "EnemyHead":
            case "EnemyBody":
                enemyScript = other.gameObject.transform.parent.gameObject.GetComponent<EnemyMove>();
                enemyScript.enemyDeath();
                break;
            case "blueTimeBall":
                isInBlue = true;
                break;
        }
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Finish" && other.gameObject.tag != "blueTimeBall")
            Destroy(transform.gameObject);      
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
}
