using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag(Tags.Friendly.ToString()))
        {
            playerHealth.DeductLive(other);
        }
    }
}
