using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int playerLives = 3;
    public float playerSpeed = 12;

    public Sprite playerSprite;
}
