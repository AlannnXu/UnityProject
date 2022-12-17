using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUIController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pausePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(false);
        Instantiate(pausePrefab);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void InGameToLevel()
    {
        SceneManager.LoadScene("Levels");
    }
    public void InGameToSetings()
    {
        SceneManager.LoadScene("Settings");
    }
}
