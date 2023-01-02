using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
     public GameObject[] enemies;

    private PlayerController playerController;
    // public GameObject enemy;
    public GameObject powerUp;
    private float xSpawnRange = 8.5f;
    private float zEnemyRange = 9.0f;
    private float ySpawn = 0.6f;
    private float zPowerupRange = -1.5f;

    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 2.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* void SpawnEnemyLinearFormation()
    {
         Vector3 spawnPos = new Vector3(xSpawnRange , ySpawn , zEnemyRange );

         for (int i = 0; i<= enemies.Length; i++)
         {
             for (int j = 0; j<= enemies.Length; j++)
             {
                 Instantiate(enemies[j], spawnPos, enemies[j].gameObject.transform.rotation);
             }
         }
        

        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupRange);

        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
    
    }
*/
    void SpawnRandomEnemy()
    {
        
        while(playerController.isGameActive)
        { 
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn , zEnemyRange);
       
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
        /*
       if(playerController.isGameActive)
        {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemyRange);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    
        }
        */
    }

    void SpawnPowerup()
    {
        while (playerController.isGameActive)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupRange);

            Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
        }
        /*
      if(playerController.isGameActive)
        {

       
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupRange);

        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
        }
        */
    }
}
