using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerPrefsController.GetPlayerScore().ToString();
        CheckForHighScore();
        bestScoreText.text = PlayerPrefsController.GetPlayerBestScore().ToString();
    }

    private void CheckForHighScore()
    {
        if (PlayerPrefsController.GetPlayerScore() > PlayerPrefsController.GetPlayerBestScore())
        {
            PlayerPrefsController.SetPlayerBestScore(PlayerPrefsController.GetPlayerScore());
            AudioManager.instance.PlayHighScoreSFX();
            animator.enabled = true;
        }
    }
}
