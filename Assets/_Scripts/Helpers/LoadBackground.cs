using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBackground : MonoBehaviour
{
    [SerializeField] private Image imageRenderer;

    private void Awake()
    {
        int numOfBackgrounds = FindObjectsOfType<LoadBackground>().Length;
        if (numOfBackgrounds > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateTheme()
    {
        if (PlayerPrefsController.GetTheme() == ThemeNames.Natural.ToString())
        {
            imageRenderer.sprite = DataPersistence.instance.naturalTheme.background;
        }
        else if (PlayerPrefsController.GetTheme() == ThemeNames.Pirate.ToString())
        {
            imageRenderer.sprite = DataPersistence.instance.pirateTheme.background;
        }
    }
}
