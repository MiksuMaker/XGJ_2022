using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMaker : MonoBehaviour
{
    [SerializeField] GameObject[] particles;
    [SerializeField] float maxLifetime = 5f;

    public void MakeParticles(int whichNumber)
    {
        GameObject _particle = Instantiate(particles[whichNumber], gameObject.transform) as GameObject;
        _particle.transform.parent = null;
        Destroy(_particle, maxLifetime);
    }

    public void MakeParticlesAtAngle(int whichNumber, float angle)
    {
        GameObject _particle = Instantiate(particles[whichNumber], gameObject.transform) as GameObject;

        // Rotate
        //_particle.transform.eulerAngles = new Vector3(-90, 0, angle);
        _particle.transform.eulerAngles = new Vector3((angle), -90, 90);

        //Debug.Log("True Angle: " + _particle.transform.eulerAngles.x);
        //Debug.Log("Given Angle: " + angle);

        _particle.transform.parent = null;
        Destroy(_particle, maxLifetime);
    }

    // RESERVE, maybe necessary for Meteor to have it's own Angle Particle Maker
    //public void MakeParticlesAtAngle(int whichNumber, float angle)
    //{
    //    GameObject _particle = Instantiate(particles[whichNumber], gameObject.transform) as GameObject;

    //    // Rotate
    //    //_particle.transform.eulerAngles = new Vector3(-90, 0, angle);
    //    _particle.transform.eulerAngles = new Vector3((angle), -90, 90);
    //    Debug.Log("True Angle: " + _particle.transform.eulerAngles.x);

    //    Debug.Log("Given Angle: " + angle);

    //    _particle.transform.parent = null;
    //    Destroy(_particle, maxLifetime);
    //}
}
