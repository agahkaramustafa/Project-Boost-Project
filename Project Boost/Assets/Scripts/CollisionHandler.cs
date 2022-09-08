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
            case "Friendly":
                Debug.Log("This is friendly");
                break;

            case "Finish":
                Debug.Log("End of the game");
                NextLevel();
                break;

            case "Fuel":
                Debug.Log("Fueled up!");
                break;

            default:
                Debug.Log("Boom!");
                ReloadScene();
                break;
        }
    }

    private static void NextLevel()
    {
        int currentSceneIndex2 = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex2 + 1;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    private static void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
