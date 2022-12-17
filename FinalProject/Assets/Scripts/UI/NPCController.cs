using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class NPCController : MonoBehaviour
{
    public Transform playerPos;
    public GameObject icon;
    public TextMeshProUGUI diaText;
    private bool ableToTalk = false;
    private bool isLighted = false;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position - playerPos.position).magnitude < 3f && !isLighted)
        {
            icon.SetActive(true);
            isLighted = true;
            ableToTalk = true;
        }
        else if((this.transform.position - playerPos.position).magnitude >= 3f)
        {
            icon.SetActive(false);
            isLighted = false; 
        }

        if(Input.GetKeyDown(KeyCode.E) && ableToTalk)
        {
            index++;
            icon.SetActive(false);
            diaText.text = "asdads";

        }
    }
}
