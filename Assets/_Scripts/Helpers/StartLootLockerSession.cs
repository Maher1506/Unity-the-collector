using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class StartLootLockerSession : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public static void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(PlayerPrefsController.GetPlayerName(), (response) =>
        {
#if UNITY_EDITOR
            if (response.success)
            {
                Debug.Log("successfully set player name");
            }
            else
            {
                Debug.Log("could not set player name" + response.Error);
            }
#endif
        });
    }

    private IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        SetPlayerName();
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                //Debug.Log("Player logged in successfully");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                StartLootLockerSession.SetPlayerName();
                done = true;
            }
            else
            {
                //Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
