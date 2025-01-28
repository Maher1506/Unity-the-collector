using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        GameManager.onScoreChanged += UpdateScoreUI;
    }

    private void OnDisable()
    {
        GameManager.onScoreChanged-= UpdateScoreUI;
    }
}