using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_WATER : SPAWNABLE
{


    [SerializeField] GameObject grassSpawn;

    private void OnEnable()
    {

        StopAllCoroutines();
        StartCoroutine(SpawnFish(7f));
        StartCoroutine(SpawnGrass(2f));
        StartCoroutine(Dissapear(15f));
    }

    IEnumerator SpawnFish(float time)
    {
        yield return new WaitForSeconds(time);


        if (planet.GetAmount(TYPETYPE.types.VEGE) < 5)
        {


            AudioManager.AUMA.playSound(AudioManager.AUMA.soKalaSpawn);

            planet.ModifyAmount(TYPETYPE.types.VEGE, 1);
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


    IEnumerator SpawnGrass(float time)
    {
        yield return new WaitForSeconds(time);



        grassSpawn.SetActive(true);

        int[] choose = new int[4];
        choose[0] = -2;
        choose[1] = -1;
        choose[2] = 1;
        choose[3] = 2;



        planet.OtherOtherCollision(grassSpawn, ListPos + choose[(int)Random.Range(0,4)]);


        StartCoroutine(SpawnFish(2f));

    }


    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        planet.setPos(ListPos, null);
        gameObject.SetActive(false);

    }





}
