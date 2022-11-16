using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class NpcDia : MonoBehaviour
{
    public GameObject tipIcon;
    public string[] dialogueContent;
    private bool canTalk = false;
    // Start is called before the first frame update
    void Start()
    {
        tipIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Talk();
            }
        }
    }

    private void Talk()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            canTalk = true; 
            tipIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tipIcon.SetActive(false);
            canTalk = false;
        }
    }
}
