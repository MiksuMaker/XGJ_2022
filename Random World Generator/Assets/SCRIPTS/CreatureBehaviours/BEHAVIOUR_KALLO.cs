using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_KALLO : SPAWNABLE
{

    [SerializeField] ParticleMaker particle;

    private void OnEnable()
    {

        StopAllCoroutines();

        StartCoroutine(Splat());
        StartCoroutine(Dissapear(5f));
    }

    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);



    }

    IEnumerator Splat()
    {

        yield return new WaitForEndOfFrame();

        if (gameObject.activeSelf)
        {
            // Particles
            //particle.MakeParticles(0);
            particle.MakeParticlesAtAngle(0, particle.GetAngle(particle.gameObject, planet.gameObject));
        }
    }
}
