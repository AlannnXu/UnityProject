using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardControl : MonoBehaviour
{
    public Transform playerPos;
    public GameObject diaBlock;
    public GameObject diaTextUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position - playerPos.position).magnitude < 2f)
        {
            diaBlock.SetActive(true);
            diaTextUI.SetActive(true);
        }
        else
        {
            diaBlock.SetActive(false);
            diaTextUI.SetActive(false);
        }
    }
}
