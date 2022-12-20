using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenControl : MonoBehaviour
{
    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        if (isStart)
        {
            Invoke("SwitchTo11", 95f);
        }
        else
        {
            Invoke("SwitchToMain", 95f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchTo11()
    {
        SceneManager.LoadScene("1-1");
    }

    public void SwitchToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
