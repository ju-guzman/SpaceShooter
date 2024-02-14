using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy Spawner")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private int enemyIncrementByWave = 5;
    [SerializeField] private float delayByEnemy = 3;
    [SerializeField] private float delayByWave = 10;

    [Header("Health Spawner")]
    [SerializeField] private GameObject healthActor;
    [SerializeField] private float delayByHealth = 30;

    private float yCameraSize;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnHealth());
        GameManager.Instance.OnGameOver += StopSpawning;
        yCameraSize = Utils.GetCameraYSizeInWorldCoordinates() - 0.5f;
    }
    private void StopSpawning()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnHealth()
    {
        while(true)
        {
            yield return new WaitForSeconds(delayByHealth * GameManager.Instance.GameSpeedMultiplier);
            Vector3 location = new(transform.position.x, Random.Range(-yCameraSize, yCameraSize), transform.position.z);
            Instantiate(healthActor, location, Quaternion.identity);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            for(int i = 0; i < enemyCount; i++)
            {
                Vector3 location = new(transform.position.x, Random.Range(-yCameraSize, yCameraSize), transform.position.z);
                Instantiate(enemies[Random.Range(0, enemies.Length)], location, Quaternion.identity);
                yield return new WaitForSeconds(Mathf.Max(1, (delayByEnemy - GameManager.Instance.GameSpeedMultiplier)));
            }
            yield return new WaitForSeconds(Mathf.Max(5, (delayByWave - GameManager.Instance.GameSpeedMultiplier)));
            enemyCount += enemyIncrementByWave;
            GameManager.Instance.LevelUp();
        }
    }
}
