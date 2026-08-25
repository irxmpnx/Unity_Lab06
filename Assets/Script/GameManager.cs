using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalCoins = 5;
    public int collectedCoins = 0;

    public float timeLimit = 180f; // 3 นาที
    private float timer;

    public Transform player;
    public float fallY = -5f;

    private bool gameEnded = false;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (gameEnded) return;

        // 1. ลดเวลา
        timer -= Time.deltaTime;

        // 2. ตรวจว่าบอลตกจาก Plane หรือยัง
        if (player.position.y < fallY)
        {
            Lose("Ball ตกจาก Plane!");
            return;
        }

        // 3. ตรวจเวลาหมด
        if (timer <= 0f)
        {
            timer = 0f;

            if (collectedCoins < totalCoins)
            {
                Lose("หมดเวลา! เก็บเหรียญไม่ครบ");
            }
            else
            {
                Win();
            }

            return;
        }

        // 4. ตรวจเก็บเหรียญครบ
        if (collectedCoins >= totalCoins)
        {
            Win();
        }
    }

    public void CollectCoin()
    {
        collectedCoins++;

        Debug.Log(
            "เก็บเหรียญ: " +
            collectedCoins + "/" +
            totalCoins
        );
    }

    void Win()
    {
        gameEnded = true;
        Debug.Log("YOU WIN!");
    }

    void Lose(string reason)
    {
        gameEnded = true;
        Debug.Log("YOU LOSE! " + reason);
    }
}
