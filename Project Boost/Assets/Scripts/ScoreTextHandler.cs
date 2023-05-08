using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;
    ScenePersist scenePersist;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scenePersist = FindObjectOfType<ScenePersist>();

        scoreText.text = $"Collected Stones: {scoreKeeper.GetCurrentScore} / {scenePersist.GetCollectibleCount}";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {scoreKeeper.GetCurrentScore} / {scenePersist.GetCollectibleCount}";
    }
}
