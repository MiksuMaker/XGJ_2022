using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour
{
    [SerializeField] GameObject[] meteorites;

    [SerializeField] GameObject[] randomPoints;


    // Variables
    [Header("Speeds")]
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;


    void Start()
    {
        MakeMeteorite();
    }


    void Update()
    {
        
    }

    //private void MakeMeteorite(Vector2 _pos, Vector2 _target, float _speed)
    private void MakeMeteorite()
    {
        // Instantiate at RandomPoint
        GameObject thisMeteorite = Instantiate(meteorites[0], randomPoints[Random.Range(0, randomPoints.Length)].transform.position, Quaternion.identity) as GameObject;

        // Calculate Fly Direction


        // Give Speed and Shoot
        Rigidbody2D rb = thisMeteorite.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * GetRandomSpeed());
    }

    private float GetRandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }
}
