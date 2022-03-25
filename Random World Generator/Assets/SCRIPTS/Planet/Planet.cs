using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;


    void Start()
    {
        
    }


    void Update()
    {
        RotatePlanet();
    }

    // ROTATION

    private void RotatePlanet()
    {
        // Turns the Planet around
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    // COLLISION

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " hit the Planet!");
        //Destroy(collision.gameObject);
    }
}
