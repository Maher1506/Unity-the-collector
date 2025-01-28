using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float deathDelay = 3f;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private LeaderboardSubmitScores leaderboardSubmit;

    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private SpriteRenderer visualRenderer;
    [SerializeField] private Sprite sadFace;

    public bool dead { get; private set; } = false;

    private int startLives = 3;
    private int lives;

    private PlayerScore playerScore;

    private void Awake()
    {
        startLives = playerData.playerLives;
    }

    private void Start()
    {
        playerScore = GetComponent<PlayerScore>();    

        lives = startLives;
        GameManager.Instance.ChangeHealth(lives);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.Damage.ToString()))
        {
            if (!dead)
            {
                DeductLive(other);
                Destroy(other.gameObject);

                if (lives <= 0)
                {
                    Die();
                }
            }
        }
    }

    public void DeductLive(Collider2D other)
    {
        faceRenderer.sprite = sadFace;

        if (!dead)
        {
            lives--;

            AudioManager.instance.PlayHitSFX();
            VFXManager.instance.CreateHitVFX(other.transform.position);

            GameManager.Instance.ChangeHealth(lives);
            if (lives <= 0 && !dead)
            {
                StartCoroutine(Die());
            }
        }
    }

    public IEnumerator Die()
    {
        StartCoroutine(leaderboardSubmit.SubmitScoreRoutine(playerScore.score));
        dead = true;

        visualRenderer.enabled = false;
        faceRenderer.enabled = false;

        AudioManager.instance.GetComponent<AudioSource>().Stop();
        AudioManager.instance.PlayDeathSFX();
        AudioManager.instance.PlayExplosionSFX();
        VFXManager.instance.CreateDeathVFX(transform.position);

        yield return new WaitForSeconds(deathDelay);

        SceneManager.LoadScene(SceneNames.GameOverScene);
    }
}
