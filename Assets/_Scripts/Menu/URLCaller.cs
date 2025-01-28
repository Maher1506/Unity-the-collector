using UnityEngine;

public class URLCaller : MonoBehaviour
{
    public void CallURL(string url)
    {
        Application.OpenURL(url);
    }
}