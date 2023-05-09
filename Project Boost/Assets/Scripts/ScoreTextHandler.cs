using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    public int collectibleCount;

    // Start is called before the first frame update
    void Awake()
    {
        collectibleCount = FindObjectsOfType<CollectibleController>().Length;
        
        scoreText.text = $"Remaining Stones: {collectibleCount}";
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
