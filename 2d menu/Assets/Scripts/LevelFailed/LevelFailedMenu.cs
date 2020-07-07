using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedMenu : MonoBehaviour
{
    private int previousSceneToLoad;
    private int nextSceneToLoad;

    public void Start()
    {
        previousSceneToLoad = SceneManager.GetActiveScene().buildIndex;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    //public void resumeLevel()
    //{ 
    //    Time.timeScale = 1; ;
    //}
    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(nextSceneToLoad);
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(previousSceneToLoad);

    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        SceneManager.LoadSceneAsync("Menu");
    }
}
