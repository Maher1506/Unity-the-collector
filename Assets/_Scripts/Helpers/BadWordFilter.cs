using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class BadWordFilter : MonoBehaviour
{
    [SerializeField] private string[] badWords;

    private TMP_InputField inputField;
    private string myString;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void ChangeName(string name)
    {
        myString = name;
        BadWordParser();
    }

    private void BadWordParser()
    {
        for (int i = 0; i < badWords.Length; i++)
        {
            if (myString.ToLower().Contains(badWords[i]))
            {
                for(int j = 0; j < badWords.Length; j++)
                {
                    if (myString.ToLower()[j] == badWords[i][0]) 
                    {
                        string temp = myString.Substring(j, badWords[i].Length);
                        if (temp.ToLower() == badWords[i])
                        {
                            myString = myString.Remove(j, badWords[i].Length);
                            if (myString != null)
                            {
                                inputField.text = myString.ToString();
                            }
                            else
                            {
                                inputField.text = "";
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}
