using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMaker : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] float lifetime = 10f;

    public void MakeParticles()
    {
        GameObject _particle = Instantiate(particle, gameObject.transform) as GameObject;
        Destroy(_particle, lifetime);
    }
}
