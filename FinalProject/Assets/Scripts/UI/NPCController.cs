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
    private bool isFinish = false;
    private int index = 0;
    private List<string> aDia = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
        aDia.Add("Perseus, I am Athena, one of the virgin goddesses");
        aDia.Add("I have come to help you slay Medusa, for I cannot tolerate Medusa's presence.");
        aDia.Add("As a mortal you are too weak, and I grant you magic treasures and my divine powers.");
        aDia.Add("I hope you will use them well and accomplish your goal.");
        aDia.Add("Now, move on.");
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position - playerPos.position).magnitude < 3f && !isLighted && !isFinish)
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
            if (index < aDia.Count)
            {
                icon.SetActive(false);
                diaText.text = aDia[index];
                index++;
            }
            else
            {
                isFinish = true;
            }
        }
    }
}
