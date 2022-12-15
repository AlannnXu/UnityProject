using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("1-1");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("1-1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("2-1");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("3-1");
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void MainToLevel()
    {
        SceneManager.LoadScene("Levels");
    }
    public void MainToSetings()
    {
        SceneManager.LoadScene("Settings");
    }
    
}
