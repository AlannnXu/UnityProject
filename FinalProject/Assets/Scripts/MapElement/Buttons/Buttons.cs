using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Transform correspondingBlockDoor;
    public bool isHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.tag == "shield") {
            Debug.Log("jinlaile");
            if (isHorizontal) {
                correspondingBlockDoor.position = new Vector3(transform.position.x, transform.position.y - 2 * Time.deltaTime, transform.position.z);
            } else {
                correspondingBlockDoor.position = new Vector3(transform.position.x + 2 * Time.deltaTime, transform.position.y, transform.position.z);
            }

        }
    }
}
