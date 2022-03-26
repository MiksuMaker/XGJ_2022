using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [Header("Gravity Stats")]
    [SerializeField] float gravityRadius = 0.7f;
    [SerializeField] float gravityStrength = 1f;


    [Header("LayerMask Affected")]
    [SerializeField] LayerMask targetMask;


    // Update is called once per frame
    void Update()
    {
        FindThingsInGravityPull();
    }


    void FindThingsInGravityPull()
    {
        //Collider2D[] thingsInPull = Physics2D.OverlapCircle(transform.position, gravityRadius, targetMask);

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, gravityRadius, targetMask);


        int debugCount = 0;

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            debugCount++;
        }

        Debug.Log("Count: " + debugCount);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }

}
