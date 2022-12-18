using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    public Transform playerPos;
    public GameObject icon;
    public TextMeshProUGUI diaText;
    private bool ableToTalk = false;
    private bool isLighted = false;
    private bool isFinish = false;
    private int index = 0;
    private int sceneNum;
    private List<string> aDia = new List<string>();
    private List<string> hDia = new List<string>();
    private List<string> zDia = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        icon.SetActive(false);
        aDia.Add("Perseus, I am Athena, one of the virgin goddesses");
        aDia.Add("I have come to help you slay Medusa, for I cannot tolerate Medusa's presence");
        aDia.Add("As a mortal you are too weak, and I grant you magic treasures and my divine powers");
        aDia.Add("I hope you will use them well and accomplish your goal");
        aDia.Add("Now, move on");
        hDia.Add("Perseus, I am Hermes, messenger of the gods");
        hDia.Add("Since Athena has given you my shoes, it is necessary for me to help you");
        hDia.Add("I give you the power of the wind, which binds all things. I hope you will use it well");
        hDia.Add("Now, move on");
        zDia.Add("Perseus, my child");
        zDia.Add("It's the first time I've seen you, but the scent of you tells me you are my child");
        zDia.Add("I am Zeus, Lord of the Gods");
        zDia.Add("Hermes has told me of your plight");
        zDia.Add("Although I can't do anything directly, but I can give you some help");
        zDia.Add("I give you the power of thunder and lightning");
        zDia.Add("it can carry you or destroy your enemies, use it well");
        zDia.Add("Now, move on");
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

    private void SwitchhDia()
    {
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
