using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score { get; private set; } = 0;

    private PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private Sprite happyFace;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        GameManager.Instance.ChangeScore(score);
        PlayerPrefsController.SetPlayerScore(score);

        faceRenderer.sprite = happyFace;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Friendly.ToString()))
        {
            if (!playerHealth.dead)
            {
                faceRenderer.sprite = happyFace;
                AddScore(other);
                Destroy(other.gameObject);
            }
        }
    }

    private void AddScore(Collider2D item)
    {
        score += item.GetComponent<FriendlyItem>().Points;

        AudioManager.instance.PlayPointSFX();
        VFXManager.instance.CreatePointVFX(item.transform.position);

        GameManager.Instance.ChangeScore(score);
        PlayerPrefsController.SetPlayerScore(score);
    }

    public void AddScoreDebugKey(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
