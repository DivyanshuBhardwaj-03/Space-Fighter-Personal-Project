using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public static DetectCollision DCInstance;
    private PlayerController playerController;
    private float timeRemaining;
    public bool timerIsRunning = false;
   
   // public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
       /* if (DCInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        DCInstance = this;

        DontDestroyOnLoad(gameObject);*/
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
       


    }

  

 /*   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Enemy") && collision.gameObject.CompareTag("Laser"))
        {
            //Debug.Log("Laser Collided with enemy");
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collided with enemy");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
      // while(playerController.isGameActive)
      //  { 
      if(playerController.isGameActive)
        {

            if(other.gameObject.CompareTag ("Powerup") && gameObject.CompareTag ("Player"))
        {
            Destroy(other.gameObject);
            playerController.UpdateLife(1);
        }
         
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Laser"))
        {
            //Debug.Log("Laser Collided with enemy");
            if (other.gameObject.CompareTag("Enemy") && other.gameObject.name == "Enemy 1(Clone)")
            {
                playerController.UpdateScore(5);
            }
            else if (other.gameObject.CompareTag("Enemy") && other.gameObject.name == "Enemy 2(Clone)")
            {
                playerController.UpdateScore(10);
            }
            else if (other.gameObject.CompareTag("Enemy") && other.gameObject.name == "Enemy 3(Clone)")
            {
                playerController.UpdateScore(15);
            }

            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
        if  (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            playerController.UpdateLife(-1);
        }
            //}

        }
    }

    public void StartSelfDestruct()
    {
        StartCoroutine(SelfDestruct());
    }

   IEnumerator SelfDestruct()
    {
       yield return new  WaitForSeconds(4f);
        Destroy(gameObject);
    }

   public void powerUpTimer()
    {
         timeRemaining = 4.0f;
         timerIsRunning = true;
         while (timerIsRunning)
         {
             if (timeRemaining > 0)
             {
                 timeRemaining -= Time.deltaTime;

             }
             else
             {
                if (gameObject.CompareTag("Powerup"))
                {
                     Destroy(gameObject);
                     timeRemaining = 0;
                     timerIsRunning = false;
                 }


             }
         }

    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
