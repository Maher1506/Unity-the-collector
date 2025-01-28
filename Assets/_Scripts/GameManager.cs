using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private ItemSpawner itemSpawner;

    [SerializeField] private CountDown countDown;
    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private int speedingInterval = 1;
    [SerializeField] private int speedToAddCap = 12;

    public bool paused { get; private set;  } = false; 
    public int speedToAdd { get; private set; } = 0;

    public static event Action<int> onScoreChanged;
    public static event Action<int> onHealthChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        ChangeTheme();
        StartCoroutine(AddSpeed());
    }

    private void ChangeTheme()
    {
        if (PlayerPrefsController.GetTheme() == ThemeNames.Natural.ToString())
        {
            itemSpawner.friendlyItems = DataPersistence.instance.naturalTheme.items;
        }
        else if (PlayerPrefsController.GetTheme() == ThemeNames.Pirate.ToString())
        {
            itemSpawner.friendlyItems = DataPersistence.instance.pirateTheme.items;
        }
    }

    private IEnumerator AddSpeed()
    {
        while (speedToAdd <= speedToAddCap)
        {
            speedToAdd++;
            
            yield return new WaitForSeconds(speedingInterval);
        }
    }

    public void Pause()
    {
        if (!countDown.doing && countDown.firstTimeDone)
        {
            AudioManager.instance.PlayClickSFX();
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);

            paused = true;
        }
    }

    public void Resume()
    {
        paused = false;

        countDown.CountDownHandler();
        AudioManager.instance.PlayClickSFX();
        pauseCanvas.SetActive(false);

    }

    public void ChangeScore(int score)
    {
        onScoreChanged?.Invoke(score);
    }

    public void ChangeHealth(int health)
    {
        onHealthChanged?.Invoke(health);
    }
}