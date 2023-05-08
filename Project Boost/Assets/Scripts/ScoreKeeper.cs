using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    int score = 0;
    public int GetCurrentScore { get {return score;} }

    void Awake()
    {
        ManageSingleton();
    }

    void Start()
    {
        
    }

    void ManageSingleton()
    { 

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ModifyScore()
    {
        score += 1;
    }

    public void ResetScore()
    {
        score = 0;
    }


}
