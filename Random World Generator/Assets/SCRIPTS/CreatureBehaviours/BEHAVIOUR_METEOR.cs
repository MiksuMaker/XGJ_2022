using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_METEOR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MeteoriteCollision>())
        {
            collision.GetComponent<MeteoriteCollision>().KillParent();
        }

    }
}
