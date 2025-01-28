using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence instance { get; set; }

    [SerializeField] public ThemeData naturalTheme;
    [SerializeField] public ThemeData pirateTheme;

    [HideInInspector] public Color selectedColor;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }
    private void Start()
    {
        selectedColor = new Color(57, 192, 97);    
    }
}
