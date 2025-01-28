using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public int itemPoints = 100;
    public int itemSpeed = 8;

    public Sprite itemSprite;
    public GameObject prefab;
}
