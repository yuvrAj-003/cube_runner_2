using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform[] spawnPoint;

    private int lastSpawnIndex = -1; // Track last spawn index

    int score = 0;

    public GameObject player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI title;
    public GameObject playButton;

    void Start()
    {
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.3f, 1.1f);
            yield return new WaitForSeconds(waitTime);

            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, spawnPoint.Length);
            }
            while (spawnIndex == lastSpawnIndex && spawnPoint.Length > 1);

            lastSpawnIndex = spawnIndex;

            Instantiate(obstacle, spawnPoint[spawnIndex].position, Quaternion.identity);
        }
    }
    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        player.SetActive(true);
        title.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine(SpawnObstacles());
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
