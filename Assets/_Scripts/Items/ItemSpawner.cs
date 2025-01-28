using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] private CountDown countDown;

    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float offset = 0.3f;

    [SerializeField] private ItemData[] damageItems;
    [SerializeField] public ItemData[] friendlyItems;

    [SerializeField] private Transform[] spawnPositions;

    private Vector3 lowerLeftCorner;
    private Vector3 lowerRightCorner;

    private float startingXPos;
    private float cameraHorizontalDistance;
    private float interval;


    void Start()
    {
        lowerLeftCorner = Camera.main.ViewportToWorldPoint(Vector3.zero);
        lowerRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));

        startingXPos = lowerLeftCorner.x + offset;

        cameraHorizontalDistance = (lowerRightCorner.x - offset) * 2;
        interval = cameraHorizontalDistance / (spawnPositions.Length - 1);

        CalculateSpawnPositions();
        StartCoroutine(SpawnItemAtRandomPosition());
    }

    private void CalculateSpawnPositions()
    {
        float positionInterval = 0f;

        foreach (var pos in spawnPositions)
        {
            pos.transform.position = new Vector2(startingXPos + positionInterval, transform.position.y);
            positionInterval += interval;
        }
    }

    private IEnumerator SpawnItemAtRandomPosition()
    {
        yield return new WaitForSeconds(4);
        
        while (true && !playerHealth.dead)
        {
            int rndSpawnPos = Random.Range(0, spawnPositions.Length);

            int itemProbability = Random.Range(0, 100);
            if (itemProbability % 5 == 0)
            {
                int rndItem = Random.Range(0, damageItems.Length);

                Instantiate(damageItems[rndItem].prefab, spawnPositions[rndSpawnPos].position, Quaternion.identity);
            }
            else
            {
                int rndItem = Random.Range(0, friendlyItems.Length);

                GameObject item = Instantiate(friendlyItems[rndItem].prefab, spawnPositions[rndSpawnPos].position, Quaternion.identity);
                item.GetComponent<FriendlyItem>().Init(friendlyItems[rndItem]);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
