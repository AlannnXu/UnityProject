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


    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position - playerPos.position).magnitude < 3f)
        {
            icon.SetActive(true);
            ableToTalk = true;
        }

        if(Input.GetKeyDown(KeyCode.E) && ableToTalk)
        {
            diaText.text = "asdada";

        }
    }
}
