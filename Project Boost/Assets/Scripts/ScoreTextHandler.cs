using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    
    public int collectibleCount;

    // Start is called before the first frame update
    void Awake()
    {
        collectibleCount = FindObjectsOfType<CollectibleController>().Length;

        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        
        scoreText.text = $"Remaining Stones: {collectibleCount}";

        if (buildIndex == SceneManager.sceneCountInBuildSettings - 2)
        {
            levelText.text = "Final Level";
        }
        else
        {
            levelText.text = "Level " + buildIndex;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyScoreText()
    {
        collectibleCount--;

        if (collectibleCount == 0)
        {
            FindObjectOfType<ToggleLights>().ToggleLight();
            scoreText.text = "Congrats! Go To The Blue Platform";
        }
        else
        {
            scoreText.text = $"Remaining Stones: {collectibleCount}";
        }
    }
}
