using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ScoreboardButton()
    {
        
    }

}
