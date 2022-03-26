using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggerGlobal : MonoBehaviour
{
    Camera camera;
    private Vector3 _dragOffset;
    [SerializeField] LayerMask targetMask;
    Collider2D[] thingsInPull;

    [Header("Distance")]
    float distance;
    [SerializeField] float minDistance = 0.2f;
    [SerializeField] float maxDistance = 4f;

    [Header("Force")]
    float force;
    [SerializeField] float maxForce = 50f;
    [SerializeField] float forceMultiplier = 10f;

    [Header("Group Grab Settings")]
    [SerializeField] float grabRadius = 1f;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        targetMask = LayerMask.GetMask("Meteorite");
    }



    private void OnMouseDown()
    {
        // Get the true point where Mouse Clicked
        _dragOffset = transform.position - GetMousePos();


        // Test the area near Mouse Click

        // Get a list of things in grabbing distance
        //Collider2D[] thingsInPull = Physics2D.OverlapCircleAll(GetMousePos(), grabRadius, targetMask);
        thingsInPull = Physics2D.OverlapCircleAll(GetMousePos(), grabRadius, targetMask);

        // Add force to each Meteor within radius towards the mouse
        //for (int i = 0; i < thingsInPull.Length; i++)
        //{
        //    Debug.Log("Number of objects in drag: " + (i + 1));
        //    thingsInPull[i].GetComponent<Dragger>().DragMeAround();
        //}
    }

    Vector3 GetMousePos()
    {
        var mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        // Cancel Z axis
        mousePos.z = 0;
        return mousePos;
    }

    //virtual public void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(GetMousePos(), grabRadius);
    //}

    private float GetDistance()
    {
        float dist = Vector2.Distance(transform.position, GetMousePos());
        return dist;
    }

    private void OnMouseDrag()
    {
        //transform.position = GetMousePos() + _dragOffset;

        // Get Mouse Pos
        //Vector2 mousePos = GetMousePos();

        // Get the Direction
        Vector2 dragDirection;
        dragDirection = GetMousePos() - transform.position;

        // Get Distance
        float dist = GetDistance();

        // Add the Force into correct direction
        //rb.AddForce(dragDirection * GetForceAmount(dist), ForceMode2D.Force);
        for (int i = 0; i < thingsInPull.Length; i++)
        {
            thingsInPull[i].GetComponent<Dragger>().DragMeAround();
        }

        //rb.AddForce(flyDirection * GetRandomSpeed(), ForceMode2D.Impulse);
    }

    private float GetForceAmount(float dist)
    {
        float force;

        if (dist <= minDistance)
        {
            // No force
            force = 0f;
            return force;
        }
        else if (distance >= maxDistance)
        {
            force = maxForce;
            return force;
        }
        else
        {
            // Calculate the force according to Distance
            force = dist * forceMultiplier * Time.deltaTime;
            return force;
        }
    }

}
