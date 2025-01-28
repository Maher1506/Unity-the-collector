using System.Security.Cryptography;
using UnityEngine;

public class FriendlyItem : MonoBehaviour
{
    public int Points { get; private set; } = 100;

    private ItemData itemData;
    private float speed;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        speed = itemData.itemSpeed + GameManager.Instance.speedToAdd;
    }

    private void Update()
    {
        transform.Translate(new Vector2(0f, -speed) * Time.deltaTime);
    }

    public void Init(ItemData datas)
    {
        itemData = datas;
        Points = itemData.itemPoints;
        spriteRenderer.sprite = itemData.itemSprite;
    }

    // Just for you to know:
    // You might sometimes see things like that:
    // 
    // public int ReturnPoints()
    //      => points;
    //
    // or 
    //
    // public void RandomFunc()
    //      => one line of code doing something;
    // 
    // This basically is a condensed way of writing either your ReturnPoints function
    // or any function that only has one line of code in it
    //
    // Not saying you should use it, although this depends on you, but at least you'll be able
    // to understand it if you come across it in the future
    // Usually, when working in teams, try to avoid this notation, as it can make it harder
    // for people to read your code fast and easily. When working alone... well that's your own call
}
