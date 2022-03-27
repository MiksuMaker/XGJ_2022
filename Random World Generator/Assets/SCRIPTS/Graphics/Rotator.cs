using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float rotationSpeed;
    float angle = 0;

    [Header("Toggles")]
    [SerializeField] bool counterClockwise = false;
    [SerializeField] bool rotateAround = false;

    [Header("Back And Forth Toggles")]
    [SerializeField] bool rotateBackAndForth = false;
    [SerializeField] bool xRotOn = true;
    [SerializeField] bool yRotOn = true;
    [SerializeField] bool zRotOn = true;

    [Header("B&F Settings")]
    [SerializeField] float xRotationModifier = 1f;
    [SerializeField] float yRotationModifier = 1f;
    [SerializeField] float zRotationModifier = 1f;

        // Stats
        #region
        float xRot = 0f;
        float yRot = 0f;
        float zRot = 0f;
    #endregion

    private void Start()
    {
        angle = Random.Range(0, 360);
    }

    void Update()
    {
        if (rotateAround) { RotateAround(); };

        if (rotateBackAndForth) { RotateBackAndForth(); }
    }
    private void RotateAround()
    {
        int factor = -1;

        if (counterClockwise)
        {
            factor = 1;
        }
        else { factor = -1; }

        transform.Rotate(0, 0, rotationSpeed * factor * Time.deltaTime);
    }

    private void RotateBackAndForth()
    {
        angle += rotationSpeed;


        // Rotation Calculations
        #region
        if (xRotOn) { xRot = Mathf.Sin(angle) * xRotationModifier; } else { xRot = 0f; }
        if (yRotOn) { yRot = Mathf.Sin(angle) * yRotationModifier; } else { yRot = 0f; }
        if (zRotOn) { zRot = Mathf.Sin(angle) * zRotationModifier; } else { zRot = 0f; }
        #endregion

        


        transform.eulerAngles = new Vector3(xRot, yRot, zRot);
    }
}
