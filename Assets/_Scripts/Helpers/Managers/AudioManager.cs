using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip pointSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip highScoreSFX;
    [SerializeField] AudioClip beepSFX;
    [SerializeField] AudioClip goSFX;
    [SerializeField] AudioClip explosionSFX;

    private AudioSource audioSource;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPointSFX() { audioSource.PlayOneShot(pointSFX); }
    public void PlayHitSFX() { audioSource.PlayOneShot(hitSFX); }
    public void PlayClickSFX() { audioSource.PlayOneShot(clickSFX); }
    public void PlayDeathSFX() { audioSource.PlayOneShot(deathSFX); }
    public void PlayHighScoreSFX() { audioSource.PlayOneShot(highScoreSFX); }
    public void PlayBeepSFX() { audioSource.PlayOneShot(beepSFX); }
    public void PlayGoSFX() { audioSource.PlayOneShot(goSFX); }
    public void PlayExplosionSFX() { audioSource.PlayOneShot(explosionSFX); }
}
