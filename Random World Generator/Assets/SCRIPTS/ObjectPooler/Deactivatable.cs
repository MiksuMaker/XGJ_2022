using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivatable : MonoBehaviour
{

    //When the object is set inactive, deactivate all coroutines
    private void OnDisable()
    {
        StopAllCoroutines();
    }


    //with this we can deactivate the object on delay
    public void DelayDeactivate(float delay)
    {
        StopAllCoroutines();
        StartCoroutine(DeactivateOnDelay(delay));

    }


    //this is the thing that does the thing that is deactivating this object on delay like really
   private IEnumerator DeactivateOnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
