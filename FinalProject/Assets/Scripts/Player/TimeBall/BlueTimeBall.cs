using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTimeBall : MonoBehaviour
{
    GameObject[] buttons;
    public bool isFound;
    public platformMove platformScript;
    public EnemyMove enemyScript;
    public Buttons buttonScript;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
        Invoke("DestroyTimeBlueBall", 5f);
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
            case "blockDoor":
            //     buttonScript = other.gameObject.GetComponent<
                isFound = false;
                Debug.Log("ss");
                foreach (GameObject b_i in buttons) {
                    Debug.Log("button name" + b_i.name);
                    buttonScript = b_i.GetComponent<Buttons>();
                    if (buttonScript.correspondingBlockDoor == other.transform) {
                        isFound = true;
                        break;
                    }
                }
                if (isFound) {
                    buttonScript.isInBlue = true;
                }
                break;                
            case "EnemyBody":
            case "EnemyHead":
                enemyScript = other.gameObject.transform.parent.GetComponent<EnemyMove>();
                enemyScript.isInBlue = true;
                break;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "platform":
                platformScript = other.gameObject.GetComponent<platformMove>();
                platformScript.isInBlue = false;
                break;
            case "EnemyBody":
            case "EnemyHead":
                enemyScript = other.gameObject.transform.parent.GetComponent<EnemyMove>();
                enemyScript.isInBlue = false;
                break;
            case "blockDoor":
                if (isFound) {
                    buttonScript.isInBlue = false;
                }                
                break;
        }        
    }

    public void DestroyTimeBlueBall() {
        Destroy(transform.gameObject);
    }
}
