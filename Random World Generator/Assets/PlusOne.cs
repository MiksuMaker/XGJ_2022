using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : SPAWNABLE
{

    [SerializeField] SpriteRenderer sr;

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(DeadOnDelay(1f));
        sr.color = new Color(1, 1, 1,1);
    }


    private void Update()
    {
        transform.position -= new Vector3(0, -0.1f * Time.deltaTime) ;
        sr.color = new Color(1, 1, 1, sr.color.a - 1f * Time.deltaTime);
    }


    IEnumerator DeadOnDelay(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }

}
