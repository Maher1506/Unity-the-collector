using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersistence : MonoBehaviour
{
    private void Awake()
    {
        int numOfCameras = FindObjectsOfType<Camera>().Length;
        if (numOfCameras > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
