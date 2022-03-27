using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollision : MonoBehaviour
{


    [SerializeField] SPAWNABLE obj;

    public void KillParent(Vector3 startPos)
    {


        //GameObject plusone = ObjectPool.SharedInstance.GetPooled_PLUSONE();




        ////now using pooler
        //if (plusone != null)
        //{

        //    // We'll assign the correct values here cuz object pooling 
        //    plusone.transform.position = new Vector3(startPos.x,startPos.y,-2f);
        //    plusone.transform.rotation = Quaternion.identity;
        //    plusone.SetActive(true);
            
        //}

        obj.Die();
    }


}
