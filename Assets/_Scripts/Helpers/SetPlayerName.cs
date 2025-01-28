using UnityEngine;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI welcomeTxt;

    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TextMeshProUGUI playerNameDefaultTxt;
    [SerializeField] private TextMeshProUGUI playerNameTxt;

    [SerializeField] private GameObject[] changeNameGO;
    [SerializeField] private GameObject[] showNameGO;

    private void Awake()
    {
        playerNameTxt.text = PlayerPrefsController.GetPlayerName();
        welcomeTxt.text = "Welcome " + playerNameTxt.text;
    }

    public void SetPlayerNameInputField()
    {
        if (string.IsNullOrEmpty(playerNameInputField.text) || string.IsNullOrWhiteSpace(playerNameInputField.text) ||
            playerNameInputField.text == PlayerPrefsController.GetPlayerName())
        {
            StartEndChangeName();
            return;
        }

        PlayerPrefsController.SetPlayerName(playerNameInputField.text);

        playerNameTxt.text = playerNameInputField.text;
        welcomeTxt.text = "Welcome " + playerNameTxt.text;
        StartEndChangeName();
    }

    public void StartEndChangeName()
    {
        bool changing = false;

        if (!playerNameInputField.gameObject.activeInHierarchy) { changing = true; }

        foreach (GameObject gameObject in showNameGO)
        {
            gameObject.SetActive(!changing);
        }

        foreach (GameObject gameObject in changeNameGO)
        {
            gameObject.SetActive(changing);
        }

        playerNameDefaultTxt.text = PlayerPrefsController.GetPlayerName();
    }
}
