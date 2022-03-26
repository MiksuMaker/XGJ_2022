using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_LAVA : SPAWNABLE
{
    private void OnEnable()
    {
        StartCoroutine(Dissapear(30f));
    }

    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        planet.setPos(ListPos, null);
        gameObject.SetActive(false);
    }

}
