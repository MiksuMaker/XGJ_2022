using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    Transform tr;


    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Flip(.5f));

    }


    IEnumerator Flip(float time)
    {
        yield return new WaitForSeconds(time);

        tr.localScale = new Vector3(-tr.localScale.x, tr.localScale.y, tr.localScale.z);
        StartCoroutine(Flip(.5f));


    }
   
}
