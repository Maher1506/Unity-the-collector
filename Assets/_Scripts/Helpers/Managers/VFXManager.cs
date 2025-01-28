using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance { get; private set; }

    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem pointVFX;
    [SerializeField] ParticleSystem deathVFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateHitVFX(Vector2 position)
    {
        Instantiate(hitVFX, position, Quaternion.identity);
    }
    public void CreatePointVFX(Vector2 position)
    {
        Instantiate(pointVFX, position, Quaternion.identity);
    }
    public void CreateDeathVFX(Vector2 position)
    {
        Instantiate(deathVFX, position, Quaternion.identity);
    }
}
