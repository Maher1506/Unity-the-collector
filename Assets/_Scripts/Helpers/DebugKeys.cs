using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeys : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerScore playerScore;

    // Update is called once per frame
    void Update()
    {
        ResetHighScore();
        Die();
        IncreaseScore();
    }

    private void ResetHighScore()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefsController.SetPlayerBestScore(0);
            Debug.LogWarning("High score resettet");
        }
    }

    private void Die()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(playerHealth.Die());
            Debug.LogWarning("Dead");
        }
    }

    private void IncreaseScore()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerScore.AddScoreDebugKey(500);
            Debug.LogWarning("Score increased");
        }
    }
}
