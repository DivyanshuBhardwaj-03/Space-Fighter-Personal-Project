using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject powerUp;

    private PlayerController playerController;
    private float xSpawnRange = 8.5f;
    private float zEnemyRange = 9.0f;
    private float ySpawn = 0.6f;
    private float zPowerupRange = -1.5f;

    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 2.0f;
   // private float startDelay = 1.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(SpawnRandomEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    void StartDelay()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomEnemy()
    {
        while(playerController.isGameActive )
        {
            yield return new WaitForSeconds(enemySpawnTime);

            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Count);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemyRange);
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while(playerController.isGameActive )
        {
           yield return new WaitForSeconds(powerupSpawnTime);
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupRange);

            Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
        }
    }
}
