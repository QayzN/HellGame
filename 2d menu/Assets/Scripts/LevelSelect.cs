using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Level1()
    {

        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Level1");
        Debug.Log("button pushed nigga");
    }
    public void Level2()
    {

        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Level2");
        Debug.Log("button pushed nigga");
    }
    public void Level3()
    {
        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Level3");
        Debug.Log("button pushed nigga");
    }
    public void Tutorial()
    {

        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Tutorial");
        Debug.Log("button pushed nigga");
    }
    public void LevelBossRun()
    {
        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("LevelBoss1");
        Debug.Log("button pushed nigga");
    }
    public void Quit()
    {

        //SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Menu");
        Debug.Log("button pushed nigga");
    }
}
