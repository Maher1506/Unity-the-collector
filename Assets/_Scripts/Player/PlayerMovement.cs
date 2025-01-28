using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [SerializeField] private float speedTouch = 6f;

    private float minXClamp;
    private float maxXClamp;
    private float offset = 0.6f;

    private float speed;
    private Vector2 targetPos;
    private float horizontalThrow;

    private PlayerHealth playerHealth;

    private Vector3 pos;

    private void Awake()
    {
        speed = playerData.playerSpeed;
    }

    private void Start()
    {
        Vector3 lowerLeftCorner = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 lowerRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0f, 0f));

        minXClamp = lowerLeftCorner.x + offset;
        maxXClamp = lowerRightCorner.x - offset;

        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (!playerHealth.dead && !GameManager.Instance.paused)
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5));
            transform.position = new Vector3(pos.x, transform.position.y, 0f); ;
            //GetInput();
            Move();
        }
    }

    private void GetInput()
    {
#if UNITY_EDITOR
        horizontalThrow = Input.GetAxis("Horizontal");
        targetPos = new Vector2(horizontalThrow * speed, 0f) * Time.deltaTime;
#endif

        if (Input.touchCount <= 0) return;

        Touch touch = Input.GetTouch(0);
        float touchDeltaX = Input.GetTouch(0).deltaPosition.x;
        targetPos = new Vector2(touchDeltaX * speedTouch, 0f) * Time.deltaTime;
    }

    private void Move()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minXClamp, maxXClamp), transform.position.y);
        transform.Translate(targetPos);
    }
}
