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
        SceneManager.LoadScene("Start");
    }

    public void Load11()
    {
        SceneManager.LoadScene("1-1");
    }
    public void Load12()
    {
        SceneManager.LoadScene("1-2");
    }
    public void Load13()
    {
        SceneManager.LoadScene("1-3");
    }
    public void Load21()
    {
        SceneManager.LoadScene("2-1");
    }
    public void Load22()
    {
        SceneManager.LoadScene("2-2");
    }
    public void Load23()
    {
        SceneManager.LoadScene("2-3");
    }
    public void Load31()
    {
        SceneManager.LoadScene("3-1");
    }
    public void Load32()
    {
        SceneManager.LoadScene("3-2");
    }
    public void Load33()
    {
        SceneManager.LoadScene("3-3");
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
