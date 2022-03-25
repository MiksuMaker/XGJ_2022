using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
        
    [SerializeField] float planetRadius = 0.4f;

    [SerializeField] GameObject TEST_OBJECT;


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
        //Debug.Log(collision.gameObject.name + " hit the Planet!");
        //Destroy(collision.gameObject);

        DoCollisionEvent(collision.gameObject);
    }

    private void DoCollisionEvent(GameObject collider)
    {
        // Calculate the angle between Planet and collider
        float angle = Mathf.Atan2(collider.transform.position.y - transform.position.y, collider.transform.position.x - transform.position.x) * 180 / Mathf.PI;

        // Calculate the correct distance for the Instantiated GameObject
        //float planetRadius = 0.4f;

        Vector2 desiredPos = transform.position;
        desiredPos = Vector2.MoveTowards(transform.position, collider.transform.position, planetRadius);

        Debug.Log("DesiredPos: " + desiredPos);

        // Add something as a child on the Planet's surface
        //GameObject thingy = Instantiate(TEST_OBJECT, collider.transform.position, Quaternion.identity) as GameObject;
        GameObject thingy = Instantiate(TEST_OBJECT, desiredPos, Quaternion.identity) as GameObject;

        // Turn the instantiated surface gameobject to the correct rotation
        thingy.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        // Make the Planet the Parent
        thingy.transform.parent = gameObject.transform;

        // Destroy the Meteorite object
        Destroy(collider);
    }
}
