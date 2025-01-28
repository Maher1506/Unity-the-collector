using UnityEngine;

public class DamageItemMovement : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private float speed;

    private void Start()
    {
        speed = itemData.itemSpeed + GameManager.Instance.speedToAdd;
    }

    private void Update()
    {
        transform.Translate(new Vector2(0f, -speed) * Time.deltaTime);
    }
}
