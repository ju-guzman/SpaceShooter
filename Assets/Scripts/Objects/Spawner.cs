using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private int enemyIncrementByWave = 5;
    [SerializeField] private float delayByEnemy = 2;
    [SerializeField] private float delayByWave = 10;

    private float yCameraSize;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        GameManager.Instance.OnGameOver += StopSpawning;
        yCameraSize = Utils.GetCameraYSizeInWorldCoordinates() - 0.5f;
    }

    private void StopSpawning()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            for(int i = 0; i < enemyCount; i++)
            {
                Vector3 location = new(transform.position.x, Random.Range(-yCameraSize, yCameraSize), transform.position.z);
                Instantiate(enemy[Random.Range(0, enemy.Length)], location, Quaternion.identity);
                yield return new WaitForSeconds(delayByEnemy);
            }
            yield return new WaitForSeconds(delayByWave);
            enemyCount += enemyIncrementByWave;
            GameManager.Instance.LevelUp();
        }
    }
}
