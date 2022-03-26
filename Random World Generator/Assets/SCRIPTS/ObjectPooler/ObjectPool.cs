using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    public List<GameObject> pooledList_METEORITE;
    public GameObject objectToPool_METEORITE;
    public int amountToPool_METEORITE;

    public List<GameObject> pooledList_VEGE;
    public GameObject objectToPool_VEGE;
    public int amountToPool_VEGE;


    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        GameObject tmp;


        //          METEORITE
        pooledList_METEORITE = new List<GameObject>();
        for(int i = 0; i < amountToPool_METEORITE; i++)
        {
            tmp = Instantiate(objectToPool_METEORITE);
            tmp.SetActive(false);
            pooledList_METEORITE.Add(tmp);
        }
        //------------------------


        //          VEGE
        pooledList_VEGE = new List<GameObject>();
        for (int i = 0; i < amountToPool_VEGE; i++)
        {
            tmp = Instantiate(objectToPool_VEGE);
            tmp.SetActive(false);
            pooledList_VEGE.Add(tmp);
        }
        //------------------------

    }



    public GameObject GetPooled_METEORITE()
    {
        for(int i = 0; i < amountToPool_METEORITE; i++)
        {
            if(!pooledList_METEORITE[i].activeInHierarchy)
            {
                return pooledList_METEORITE[i];
            }
        }
        return null;
    }


    public GameObject GetPooled_VEGE()
    {
        for (int i = 0; i < amountToPool_VEGE; i++)
        {
            if (!pooledList_VEGE[i].activeInHierarchy)
            {
                return pooledList_VEGE[i];
            }
        }
        return null;
    }


}
