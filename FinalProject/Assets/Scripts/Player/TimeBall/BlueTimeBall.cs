using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlueTimeBall : MonoBehaviour
{
    GameObject[] buttons;
    public bool isFound;
    public bool isFound2;
    public platformMove platformScript;
    public EnemyMove enemyScript;
    public Buttons buttonScript;
    
    public TextMeshProUGUI countDownText;
    private float count = 7f;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
        
        Invoke("DestroyTimeBlueBall", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        countDownText.text = Mathf.Floor(count).ToString();
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

                foreach (GameObject b_i in buttons) {
                    Debug.Log("button name" + b_i.name);
                    buttonScript = b_i.GetComponent<Buttons>();
                    if (buttonScript.correspondingBlockDoor == other.transform) {
                        isFound = true;
                        break;
                    } else if (buttonScript.correspondingBlockDoor2 == other.transform) {
                        buttonScript.isInBlue2 = true;
                        isFound2 = true;
                        break;
                    }
                }
                if (isFound) {
                    buttonScript.isInBlue = true;
                }
                break;                
            case "EnemyBody":
                enemyScript = other.gameObject.GetComponent<EnemyMove>();
                enemyScript.isInBlue = true;
                break;            
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
                enemyScript = other.gameObject.GetComponent<EnemyMove>();
                enemyScript.isInBlue = false;
                break;
            case "EnemyHead":
                enemyScript = other.gameObject.transform.parent.GetComponent<EnemyMove>();
                enemyScript.isInBlue = false;
                break;
            case "blockDoor":
                if (isFound) {
                    buttonScript.isInBlue = false;
                }
                if (isFound2) {
                    buttonScript.isInBlue2 = false;
                }                
                break;
        }        
    }

    public void DestroyTimeBlueBall() {
        Destroy(transform.gameObject);
    }
}
