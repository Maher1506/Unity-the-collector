using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color color;

    private void Awake()
    {
        spriteRenderer.sprite = playerData.playerSprite;
        if (DataPersistence.instance.selectedColor == new Color(57, 192, 97))
        {
            return;
        }
        else
        {
            spriteRenderer.color = DataPersistence.instance.selectedColor;
        }
        
        //ensures the visual is opaque
        color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
