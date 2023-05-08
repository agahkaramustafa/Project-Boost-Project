using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    int collectibleCount;
    public int GetCollectibleCount { get {return collectibleCount;} }

    void Awake() 
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        collectibleCount = FindObjectsOfType<CollectibleController>().Length;
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
