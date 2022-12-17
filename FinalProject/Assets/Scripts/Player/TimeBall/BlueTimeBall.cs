using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTimeBall : MonoBehaviour
{
    public platformMove platformScript;
    public EnemyMove enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "platform":
                platformScript = other.gameObject.GetComponent<platformMove>();
                platformScript.isInBlue = true;
                break;
            case "EnemyBody":
            case "EnemyHead":
                enemyScript = other.gameObject.transform.parent.GetComponent<EnemyMove>();
                
                break;

        }
    }
}
