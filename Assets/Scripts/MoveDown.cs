using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed =5.0f;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Moving Enemy from top to bottom

       // transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        objectRb.AddForce(Vector3.back  * speed);                       // back is used to move object from top to bottom of screen alternatively negative of Speed can be used to achieve the same objective
    }
}
