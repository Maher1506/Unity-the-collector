using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDown;

    public bool doing { get; private set; } = false;
    public bool firstTimeDone { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        CountDownHandler();
    }

    public void CountDownHandler()
    {
        if (firstTimeDone)
        {
            StartCoroutine(ResumeCountDownRoutine());
        }
        else
        {
            StartCoroutine(FirstCountDownRoutine());
        }
    }

    private IEnumerator FirstCountDownRoutine()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        countDown.text = "3";
        countDown.enabled = true;
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(1);
        countDown.enabled = false;
        countDown.text = "2";
        countDown.enabled = true;
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(1);
        countDown.enabled = false;
        countDown.text = "1";
        countDown.enabled = true; 
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(1);
        countDown.enabled = false;
        countDown.text = "GO";
        countDown.enabled = true;
        AudioManager.instance.PlayGoSFX();

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.enabled = false;

        AudioManager.instance.GetComponent<AudioSource>().Play();
        firstTimeDone = true;
    }

    private IEnumerator ResumeCountDownRoutine()
    {
        doing = true;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(0.25f);
        countDown.text = "3";
        countDown.enabled = true;
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.enabled = false;
        countDown.text = "2";
        countDown.enabled = true;
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.enabled = false;
        countDown.text = "1";
        countDown.enabled = true;
        AudioManager.instance.PlayBeepSFX();

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.enabled = false;
        countDown.text = "GO";
        countDown.enabled = true;
        AudioManager.instance.PlayGoSFX();

        Time.timeScale = 1f;

        yield return new WaitForSecondsRealtime(0.25f);
        countDown.enabled = false;

        doing = false;
    }
}
