using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    public Transform playerPos;
    public Player playerScript;
    public GameObject icon;
    public GameObject diaBlock;
    public GameObject diaTextUI;
    public TextMeshProUGUI diaText;

    private bool ableToTalk = false;
    private bool isLighted = false;
    public bool isFinish = false;
    private bool isTalking = false;
    private int index = 0;
    private int sceneNum;
    private List<string> aDia = new List<string>();
    private List<string> hDia = new List<string>();
    private List<string> zDia = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        diaText = diaTextUI.GetComponent<TextMeshProUGUI>();
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        diaBlock.SetActive(false);
        icon.SetActive(false);
        diaTextUI.SetActive(false);
        aDia.Add("Perseus, I am Athena, one of the virgin goddesses.");
        aDia.Add("I'm here to help you slay Medusa, for I cannot tolerate Medusa's presence.");
        aDia.Add("As a mortal you are too weak, so I will grant you a copy of my shield, it has magical power of me.");
        aDia.Add("I hope you will use them well and accomplish your goal.");
        aDia.Add("Now, go ahead!");
        hDia.Add("Perseus, I am Hermes, messenger of the gods.");
        hDia.Add("Since Athena has given you my shoes, it is necessary for me to help you.");
        hDia.Add("I give you the power of the wind, which binds all things in an area.");
        hDia.Add("I hope you will use it well.");
        hDia.Add("Now, go ahead!");
        zDia.Add("Perseus, my child.");
        zDia.Add("It's the first time I've seen you, but the scent of you tells me you are my child.");
        zDia.Add("I am Zeus, Lord of the Gods.");
        zDia.Add("Hermes has told me of your plight.");
        zDia.Add("Although I can't do anything directly, but I can give you some help.");
        zDia.Add("I give you the power of thunder and lightning.");
        zDia.Add("it can carry you or destroy your enemies, use it well.");
        zDia.Add("Now, go ahead!");
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position - playerPos.position).magnitude < 3f && !isLighted && !isFinish)
        {
            if (!isTalking)
            {
                icon.SetActive(true);
            }
            else
            {
                diaBlock.SetActive(true);
            }
            diaTextUI.SetActive(true);
            isLighted = true;
            ableToTalk = true;
        }
        else if((this.transform.position - playerPos.position).magnitude >= 3f)
        {
            diaBlock.SetActive(false);
            diaTextUI.SetActive(false);
            icon.SetActive(false);
            isLighted = false; 
        }

        if(Input.GetKeyDown(KeyCode.E) && ableToTalk)
        {
            if (!isFinish)
            {
                diaBlock.SetActive(true);
            }
            switch (sceneNum)
            {
                case 3:
                    SwitchaDia();
                    break;
                case 6:
                    SwitchhDia();
                    break;
                case 9:
                    SwitchzDia();
                    break;

            }
        }
    }


    private void SwitchaDia()
    {
        isTalking = true;

        if (index < aDia.Count)
        {
            icon.SetActive(false);
            diaText.text = aDia[index];
            index++;
        }
        else
        {
            isFinish = true;
            playerScript.shieldPrefab.gameObject.SetActive(true);
            playerScript.status++;
        }
    }

    private void SwitchhDia()
    {
        isTalking = true;
        if (index < hDia.Count)
        {
            icon.SetActive(false);
            diaText.text = hDia[index];
            index++;
        }
        else
        {
            isFinish = true;
        }
    }

    private void SwitchzDia()
    {
        isTalking = true;
        if (index < zDia.Count)
        {
            icon.SetActive(false);
            diaText.text = zDia[index];
            index++;
        }
        else
        {
            isFinish = true;
        }
    }

}
