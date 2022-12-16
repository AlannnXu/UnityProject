using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Transform correspondingBlockDoor;
    public bool isHorizontal;
    private Vector3 initPos;
    public bool isOnButton;
    public bool isNeedToIncrease;
    public float DoorSpeed = 2.2f;
    public float buttonSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        isNeedToIncrease = false;
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnButton && isNeedToIncrease) {
                transform.position = new Vector3(transform.position.x, 
                    transform.position.y + buttonSpeed * Time.deltaTime, transform.position.z);
                correspondingBlockDoor.position = new Vector3(correspondingBlockDoor.position.x, 
                    correspondingBlockDoor.position.y + DoorSpeed * Time.deltaTime, correspondingBlockDoor.position.z);  
                if (Vector3.Distance(transform.position, initPos) < 0.01f) isNeedToIncrease = false;        
        }
    }



    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player" && other.gameObject.tag == "shield") {
    //         Debug.Log("jinlaile");                         
    //         if (isHorizontal) {
    //             correspondingBlockDoor.position = new Vector3(transform.position.x, transform.position.y - 2 * Time.deltaTime, transform.position.z);
    //         } else {
    //             correspondingBlockDoor.position = new Vector3(transform.position.x + 2 * Time.deltaTime, transform.position.y, transform.position.z);
    //         }

    //     }
    // }
}
