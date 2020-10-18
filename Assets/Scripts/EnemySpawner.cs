using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private float spawnInterval = .5f;
    [SerializeField] private GameObject friendPrefab = null;
    [SerializeField] private float friendSpawnInterval = 2f;

    private float currentSpawnInterval;
    private float currentFriendSpawnInterval;

    private float speedAdd = 0;

    void Update()
    {
        currentSpawnInterval -= Time.deltaTime;
        if(currentSpawnInterval <= 0)
        {
            currentSpawnInterval = spawnInterval;
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5f), 6, 0), Quaternion.identity);
            enemy.GetComponent<Bullet>().Power -= speedAdd;
            speedAdd += .1f;
            spawnInterval = Mathf.Max(0.05f, spawnInterval - 0.005f);
        }

        currentFriendSpawnInterval -= Time.deltaTime;
        if (currentFriendSpawnInterval <= 0)
        {
            currentFriendSpawnInterval = friendSpawnInterval;
            GameObject friend = Instantiate(friendPrefab, new Vector3(Random.Range(-5f, 5f), 6, 0), Quaternion.identity);
            friend.GetComponent<Bullet>().Power -= speedAdd;
        }
    }
}
