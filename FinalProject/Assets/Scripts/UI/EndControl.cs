using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SwitchTo11", 93f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchTo11()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
