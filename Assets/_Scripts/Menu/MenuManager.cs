using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toHideGO;
    [SerializeField] private GameObject[] menuGO;

    public void OpenCloseMenu()
    {
        bool open = false;

        foreach (GameObject item in menuGO)
        {

            if (!item.activeInHierarchy) { open = true; }

        }

        foreach (GameObject item in menuGO)
        {
            item.SetActive(open);
        }

        foreach (GameObject go in toHideGO)
        {
            go.SetActive(!open);
        }
    }
}