using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_KALLO : SPAWNABLE
{

    private void OnEnable()
    {

        StopAllCoroutines();
        StartCoroutine(Dissapear(5f));
    }

    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);



    }
}
