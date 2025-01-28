using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    [SerializeField] private int scoreForPirate = 1000;

    [SerializeField] private Toggle naturalToggle;
    [SerializeField] private Toggle pirateToggle;

    [SerializeField] private GameObject pirateText;

    private void Start()
    {
        print(PlayerPrefsController.GetTheme());
        if (PlayerPrefsController.GetPlayerBestScore() > scoreForPirate)
        {
            pirateToggle.interactable = true;
            pirateText.SetActive(false);
        }

        if (PlayerPrefsController.GetTheme() == ThemeNames.Natural.ToString())
        {
            naturalToggle.isOn = true;
            pirateToggle.isOn = false;
        }
        else if (PlayerPrefsController.GetTheme() == ThemeNames.Pirate.ToString())
        {
            pirateToggle.isOn = true;
            naturalToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerPrefsController.GetTheme());
        CheckTheme();
    }

    private void CheckTheme()
    {
        if (naturalToggle.isOn)
        {
            PlayerPrefsController.SetTheme(ThemeNames.Natural.ToString());
            FindObjectOfType<LoadBackground>().UpdateTheme();
        }
        else if (pirateToggle.isOn)
        {
            PlayerPrefsController.SetTheme(ThemeNames.Pirate.ToString());
            FindObjectOfType<LoadBackground>().UpdateTheme();
        }
    }
}
