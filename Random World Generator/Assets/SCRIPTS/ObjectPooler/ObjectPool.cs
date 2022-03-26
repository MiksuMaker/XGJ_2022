using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    [SerializeField] Planet planet;


    public List<GameObject> pooledList_METEORITE;
    public GameObject objectToPool_METEORITE;
    public int amountToPool_METEORITE;

    public List<GameObject> pooledList_VEGE;
    public GameObject objectToPool_VEGE;
    public int amountToPool_VEGE;


    public List<GameObject> pooledList_WATER;
    public GameObject objectToPool_WATER;
    public int amountToPool_WATER;


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
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_VEGE.Add(tmp);
        }
        //------------------------


        //          WATER
        pooledList_WATER = new List<GameObject>();
        for (int i = 0; i < amountToPool_WATER; i++)
        {
            tmp = Instantiate(objectToPool_WATER);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_VEGE.Add(tmp);
        }
        //------------------------

    }



    public GameObject GetPooled_METEORITE()
    {

        for(int i = 0; i < pooledList_METEORITE.Count; i++)
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




    public GameObject GetPooled_WATER()
    {
        for (int i = 0; i < amountToPool_WATER; i++)
        {
            if (!pooledList_WATER[i].activeInHierarchy)
            {
                return pooledList_WATER[i];
            }
        }
        return null;
    }


}
