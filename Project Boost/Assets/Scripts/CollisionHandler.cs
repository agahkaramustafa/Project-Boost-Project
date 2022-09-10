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

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevelSequence();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;

            case "Finish":
                Debug.Log("End of the game");
                NextLevelSequence();
                break;

            default:
                Debug.Log("Boom!");
                StartCrashSequence();
                break;
        }
        
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        crashParticle.Play();
        audioSource.PlayOneShot(crashSound, 0.7f);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delay);
    }

    void NextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successParticle.Play();
        audioSource.PlayOneShot(successSound);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }

    public void NextLevel()
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
