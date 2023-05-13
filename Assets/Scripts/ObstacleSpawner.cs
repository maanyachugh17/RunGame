using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnDelay = 3f;
    public float spawnRange = 10f;
    public float obstacleLifetime = 4f;
    public float obstacleMoveSpeed = 5f; // new variable for move speed

    private Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnRange;
            spawnPosition.y = obstaclePrefab.transform.position.y-0.5f;

            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            obstacle.GetComponent<Rigidbody>().velocity = Vector3.back * obstacleMoveSpeed;

            Destroy(obstacle, obstacleLifetime);
        }
    }
}
