using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollision : MonoBehaviour
{


    [SerializeField] SPAWNABLE obj;

    public void KillParent()
    {
        obj.Die();
    }


}
