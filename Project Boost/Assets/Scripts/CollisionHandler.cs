using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;

            case "Finish":
                Debug.Log("End of the game");
                NextLevelSequence();
                break;

            case "Fuel":
                Debug.Log("Fueled up!");
                break;

            default:
                Debug.Log("Boom!");
                StartCrashSequence();
                break;
        }
    }
    void StartCrashSequence()
    {

        audioSource.PlayOneShot(crashSound, 0.7f);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delay);
    }

    void NextLevelSequence()
    {
        audioSource.PlayOneShot(successSound);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }

    void NextLevel()
    {
        int currentSceneIndex2 = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex2 + 1;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
