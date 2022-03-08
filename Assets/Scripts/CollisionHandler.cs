using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                ReloadLevel();
                break;
            case "Fuel":
                Debug.Log("You got fuel");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                Debug.Log("You are launching");
                break;
        }
    }

    void ReloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = sceneIndex + 1;
        //int amountOfScenes = SceneManager.GetAllScenes().Length;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        /*if (sceneIndex + 1 != amountOfScenes)
            SceneManager.LoadScene(sceneIndex + 1);
        else SceneManager.LoadScene(0);*/
    }
}
