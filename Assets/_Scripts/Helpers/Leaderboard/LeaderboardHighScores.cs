using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardHighScores : MonoBehaviour
{
    private const string PLAYER_NAME = "Player Names";
    private const string PLAYER_SCORE = "Player Scores";

    [SerializeField] private GameObject leaderboardSlotPrefab;
    [SerializeField] private Transform leaderboardSlotParent;

    private List<GameObject> slots = new List<GameObject>();

    string leaderboardID = "Global_Leaderboard_HighScore";

    private void Awake()
    {
        StartCoroutine(FetchTopHighScores());
    }

    public IEnumerator FetchTopHighScores()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    GameObject slot = Instantiate(leaderboardSlotPrefab, leaderboardSlotParent);

                    slot.transform.Find(PLAYER_NAME).GetComponent<TextMeshProUGUI>().text = members[i].player.name;
                    slot.transform.Find(PLAYER_SCORE).GetComponent<TextMeshProUGUI>().text = members[i].score.ToString();

                    slots.Add(slot);
                }
                done = true;
            }
            else
            {
                Debug.Log("failed " + response.Error);
                done = true;
            }
        }); 
        yield return new WaitWhile( () => done == false);   
    }
}
