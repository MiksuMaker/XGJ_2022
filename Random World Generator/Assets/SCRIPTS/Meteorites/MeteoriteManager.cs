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
        // Get birth Position
        Transform birthPos;
        birthPos = randomPoints[Random.Range(0, randomPoints.Length)].transform;

        // Get Target Pos   (1/2)
        Transform targetPos;
        bool targetFound = false;

        // Set initial target Pos and test if it is the same as birthPos    (2/2)
        targetPos = randomPoints[Random.Range(0, randomPoints.Length)].transform;
        while(!targetFound)
        {

            if (targetPos != birthPos)
            {
                targetFound = true;
                break;
            }

            // Try again
            targetPos = randomPoints[Random.Range(0, randomPoints.Length)].transform;

            // Test if the randomPoints array is empty
            if (randomPoints.Length <= 0)
            {
                Debug.LogError("Random Points list is empty!");
                targetPos = gameObject.transform;
            }
        }


        // Instantiate at RandomPoint
        GameObject thisMeteorite = Instantiate(meteorites[0], birthPos.position, Quaternion.identity) as GameObject;

        // Calculate Fly Direction
        Vector2 flyDirection = targetPos.position - birthPos.position;
        Debug.Log("TargetPos: " + targetPos.position);
        Debug.Log("BirthPos: " + birthPos.position);

        // Give Speed and Shoot
        Rigidbody2D rb = thisMeteorite.GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.left * GetRandomSpeed());     // Old, delete
        rb.AddForce(flyDirection * GetRandomSpeed());
    }

    private float GetRandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    //private Transform GetTarget(GameObject birthPos)
    //{
        
    //}
}
