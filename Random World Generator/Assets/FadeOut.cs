using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    private void Update()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - .6f * Time.deltaTime);
        if (sr.color.a <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
