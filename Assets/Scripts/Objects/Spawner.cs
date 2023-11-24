using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    private float yCameraSize;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        yCameraSize = Utils.GetCameraYSizeInWorldCoordinates() - 0.5f;
    }

    IEnumerator SpawnEnemies()
    {
        Vector3 location = new(transform.position.x, Random.Range(-yCameraSize, yCameraSize), transform.position.z);
        Instantiate(enemy[Random.Range(0, enemy.Length)], location, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }

    void Update()
    {

    }
}
