using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_KALLO : SPAWNABLE
{

    private void OnEnable()
    {
        StartCoroutine(Dissapear(15f));
    }

    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);



    }
}
