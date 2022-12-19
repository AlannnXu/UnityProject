using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Transform correspondingBlockDoor;
    public Transform correspondingBlockDoor2;
    public Transform correspondingBlockDoorTmp;
    public BlockDoor blockDoorScript;
    public BlockDoor blockDoorScript2;
    public bool flag1;
    public bool flag2;
    public bool forceStop;
    public bool forceStop2;
    private Vector3 initPos;
    private Vector3 initPos2;
    public bool isOnButton;
    public bool isInBlue;
    public bool isInBlue2;
    public bool isNeedToIncrease;
    public bool isNeedToIncrease2;
    public float DoorSpeed = 2.2f;
    public float buttonSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        isNeedToIncrease = false;
        
        if (correspondingBlockDoor != null) {
            blockDoorScript = correspondingBlockDoor.GetComponent<BlockDoor>();
            flag1 = blockDoorScript.flag;
            initPos = correspondingBlockDoor.position;
        }
        if (correspondingBlockDoor2 != null) {
            blockDoorScript2 = correspondingBlockDoor2.GetComponent<BlockDoor>();
            flag2 = blockDoorScript2.flag;
            initPos2 = correspondingBlockDoor2.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnButton && isNeedToIncrease && !forceStop && (correspondingBlockDoor != null)) {
            if (!isInBlue) {
                transform.position = new Vector3(transform.position.x, 
                    transform.position.y + buttonSpeed * Time.deltaTime, transform.position.z);            
                if (!flag1) {
                    correspondingBlockDoor.position = new Vector3(correspondingBlockDoor.position.x, 
                        correspondingBlockDoor.position.y + DoorSpeed * Time.deltaTime, correspondingBlockDoor.position.z); 
                } else {
                    correspondingBlockDoor.position = new Vector3(correspondingBlockDoor.position.x - DoorSpeed * Time.deltaTime, 
                        correspondingBlockDoor.position.y, correspondingBlockDoor.position.z);                 
                }

 
                if (Vector3.Distance(correspondingBlockDoor.position, initPos) < 0.01f || correspondingBlockDoor.position.y > initPos.y) {
                    isNeedToIncrease = false; 
                    forceStop = true;
                }   
            } else {

            }
    
        }
        if (!isOnButton && isNeedToIncrease2 && !forceStop2 && (correspondingBlockDoor2 != null) && !isInBlue2) {
            if (!isInBlue2) {
                if (!flag2) {
                    correspondingBlockDoor2.position = new Vector3(correspondingBlockDoor2.position.x, 
                        correspondingBlockDoor2.position.y + DoorSpeed * Time.deltaTime, correspondingBlockDoor2.position.z);
                } else {
                    correspondingBlockDoor2.position = new Vector3(correspondingBlockDoor2.position.x - DoorSpeed * Time.deltaTime, 
                        correspondingBlockDoor2.position.y, correspondingBlockDoor2.position.z);                
                }
                if (Vector3.Distance(correspondingBlockDoor2.position, initPos2) < 0.01f) {
                    isNeedToIncrease2 = false; 
                    forceStop2 = true;
                }                
            } else {
                
            }


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
