using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBall : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public EnemyMove enemyScript;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + Time.fixedDeltaTime *  new Vector2(speed, 0));
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(Time.time + ":进入thunderBall触发器的对象是：" + other.gameObject.name);
        switch (other.gameObject.tag) {
            case "EnemyHead":
            case "EnemyBody":
                enemyScript = other.gameObject.transform.parent.gameObject.GetComponent<EnemyMove>();
                enemyScript.enemyDeath();
                break;
        }
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Finish")
            Destroy(transform.gameObject);      
    }
}
