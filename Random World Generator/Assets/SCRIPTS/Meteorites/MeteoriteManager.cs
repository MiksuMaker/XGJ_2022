using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour
{
    [SerializeField] GameObject[] meteorites;

    [SerializeField] GameObject[] randomPoints;

    [Header("Targeting Points")]
    [SerializeField] GameObject throwerMount;
    [SerializeField] GameObject targetMount;

    [SerializeField] GameObject throwerPoint;
    [SerializeField] GameObject targetPoint;

    [Header("Targeting Stats")]
    [SerializeField] float minRotation = 0f;
    [SerializeField] float maxRotation = 40f;


    // Variables
    [Header("Speeds")]
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;

    [Header("Bools")]
    [SerializeField] private bool meteoriteSpawningOn = true;


    void Start()
    {
        //MakeMeteorite();
        //ThrowMeteorite();

        StartCoroutine(MeteoriteThrower());
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

    private float GetRandomRotation()
    {
        return Random.Range(0f, 360f);
    }

    private void ThrowMeteorite()
    {
        float rotationDegree = GetRandomRotation();

        // Rotate Thrower Mount to random degree
        throwerMount.transform.eulerAngles = new Vector3(0, 0, rotationDegree);

        // Limit the Random Rotation
        float currentRotation = Random.Range(minRotation, maxRotation);
        int[] factor = new int[] { -1, 1 };
        currentRotation *= factor[Random.Range(0,2)];

        // Rotate Target Mount opposite of ThrowerPoint
        targetMount.transform.eulerAngles = new Vector3(0, 0, rotationDegree + 180 + currentRotation);


        // Calculate the Fly Direction
        Vector2 flyDirection = targetPoint.transform.position - throwerPoint.transform.position;

        // Create the Meteorite
        GameObject meteorite = Instantiate(meteorites[0], throwerPoint.transform.position, Quaternion.identity) as GameObject;

        // Give the Meteorite a push!
        Rigidbody2D rb = meteorite.GetComponent<Rigidbody2D>();
        rb.AddForce(flyDirection * GetRandomSpeed(), ForceMode2D.Impulse);


        // Destroy the Meteorite after some time
        Destroy(meteorite, 10f);
    }

    private IEnumerator MeteoriteThrower()
    {
        while (meteoriteSpawningOn)
        {
            // Throw a Meteorite!
            ThrowMeteorite();

            yield return new WaitForSeconds(1f);
        }
    }
}
