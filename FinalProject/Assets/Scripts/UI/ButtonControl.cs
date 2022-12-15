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

<<<<<<< Updated upstream
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
    public void Pause()
    {
        Time.timeScale = 0f;
=======
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);

    }

    public void Settings()
    {
        SceneManager.LoadScene(2);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevel_1()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToLevel_1_1()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToLevel_1_2()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToLevel_1_3()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToLevel_2()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToLevel_2_1()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToLevel_2_2()
    {
        SceneManager.LoadScene(7);
    }

    public void GoToLevel_2_3()
    {
        SceneManager.LoadScene(8);
    }

    public void GoToLevel_3()
    {
        SceneManager.LoadScene(9);
    }

    public void GoToLevel_3_1()
    {
        SceneManager.LoadScene(9);
    }

    public void GoToLevel_3_2()
    {
        SceneManager.LoadScene(10);
    }

    public void GoToLevel_3_3()
    {
        SceneManager.LoadScene(11);
>>>>>>> Stashed changes
    }
}
