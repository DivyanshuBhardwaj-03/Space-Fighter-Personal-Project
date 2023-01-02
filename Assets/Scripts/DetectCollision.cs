using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private PlayerController playerController;
   
   // public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
