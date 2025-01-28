using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthTxt;

    public void UpdateHealthUI(int health)
    {
        healthTxt.text = health.ToString();
    }

    private void OnEnable()
    {
        GameManager.onHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        GameManager.onHealthChanged -= UpdateHealthUI;
    }
}