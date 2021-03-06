using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorVFX : MonoBehaviour
{
    ParticleMaker particle;
    
    float waitingPeriod = 1f;

    float soundDelay = .1f;
    bool canPlaySound = true;




    private void Start()
    {
        particle = GetComponent<ParticleMaker>();

        if (!particle) { Debug.LogError("Meteorite has no ParticleMaker Script attached!"); }

        StartCoroutine(DropSpaceDust());
    }


    private IEnumerator DropSpaceDust()
    {
        while(true)
        {
            // Drop the dust
            particle.MakeParticles(0);

            // Wait and create new waitingPeriod
            yield return new WaitForSeconds(waitingPeriod);
            waitingPeriod = Random.Range(1f, 3f);
        }
    }




    private IEnumerator CanPlaySoundAgain(float time)
    {
        yield return new WaitForSeconds(time);
        canPlaySound = true;

    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check whether the collision was with another Meteorite

        //if (collision.gameObject.GetComponent<MeteorVFX>())
        if (collision.gameObject.GetComponent<Dragger>())
        {
            // Do the Bump
            particle.MakeParticles(1);

            // MAKE A SOUND ------------------------------------------------------------------------- HERE
            if (canPlaySound) {

                if (gameObject.activeSelf)
                {
                    AudioManager.AUMA.playSound(AudioManager.AUMA.soSound1);
                    canPlaySound = false;
                    StartCoroutine(CanPlaySoundAgain(soundDelay));
                }

                }
        }
        else if (collision.gameObject.GetComponent<Planet>())
        {
            // Calculate rotation
            float angle = Mathf.Atan2(collision.transform.position.y - transform.position.y, collision.transform.position.x - transform.position.x) * 180 / Mathf.PI;
            // Instantiate impact
            particle.MakeParticlesAtAngle(2, angle);

        }
    }

}
