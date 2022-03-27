using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_LAVA : SPAWNABLE
{


    [SerializeField] GameObject fireObj;

    int[] pose = new int[4];


    private void Start()
    {
        pose[0] = -2;
        pose[1] = -1;
        pose[2] = 1;
        pose[3] = 2;
    }
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnLihis(7f));
        StartCoroutine(SpawnFire(2f));
        StartCoroutine(Dissapear(15f));
    }

    IEnumerator SpawnLihis(float time)
    {
        yield return new WaitForSeconds(time);


        if (planet.GetAmount(TYPETYPE.types.LIHIS) < 5)
        {

            GameObject vege = ObjectPool.SharedInstance.GetPooled_LIHIS();

            planet.ModifyAmount(TYPETYPE.types.LIHIS, 1);

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

        StartCoroutine(SpawnLihis(10f));

    }



    IEnumerator SpawnFire(float time)
    {
        yield return new WaitForSeconds(time);


        int curPos = pose[Random.Range(0, 4)];

        if (planet.GetPosType(curPos) == TYPETYPE.types.GRASS)
        {
            planet.GetPos(curPos).GetComponent<BEHAVIOUR_GRASS>().setOnFire();
        }

        

        StartCoroutine(SpawnFire(2f));

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
