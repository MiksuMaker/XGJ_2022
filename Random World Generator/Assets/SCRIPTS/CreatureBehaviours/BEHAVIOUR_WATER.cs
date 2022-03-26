using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_WATER : SPAWNABLE
{
    private void OnEnable()
    {
        StartCoroutine(SpawnFish(2f));
        StartCoroutine(Dissapear(30f));
    }

    IEnumerator SpawnFish(float time)
    {
        yield return new WaitForSeconds(time);


        if (planet.GetAmount(TYPETYPE.types.VEGE) < 5)
        {

            GameObject vege = ObjectPool.SharedInstance.GetPooled_VEGE();

            //now using pooler
            if (vege != null)
            {
                // We'll assign the correct values here cuz object pooling 
                vege.transform.position = transform.position;
                vege.GetComponent<SPAWNABLE>().SetListPos(ListPos);
                vege.transform.eulerAngles = transform.eulerAngles;

                vege.SetActive(true);
            }
        }

            StartCoroutine(SpawnFish(10f));

    }


    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        planet.setPos(ListPos, null);
        gameObject.SetActive(false);

        

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("WW");

        TYPETYPE other = collision.gameObject.GetComponent<TYPETYPE>();
        if (other != null)
        {
            if (other.getType() == TYPETYPE.types.VEGE) { other.gameObject.GetComponent<BEHAVIOUR_VEGE>().Die(); }
        }
    }


}
