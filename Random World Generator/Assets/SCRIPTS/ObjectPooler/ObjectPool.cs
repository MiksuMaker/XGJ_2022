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

    public List<GameObject> pooledList_LIHIS;
    public GameObject objectToPool_LIHIS;
    public int amountToPool_LIHIS;


    public List<GameObject> pooledList_LAVA;
    public GameObject objectToPool_LAVA;
    public int amountToPool_LAVA;


    public List<GameObject> pooledList_CLOUD;
    public GameObject objectToPool_CLOUD;
    public int amountToPool_CLOUD;

    public List<GameObject> pooledList_STEAM;
    public GameObject objectToPool_STEAM;
    public int amountToPool_STEAM;

    public List<GameObject> pooledList_WATER;
    public GameObject objectToPool_WATER;
    public int amountToPool_WATER;

    public List<GameObject> pooledList_GRASS;
    public GameObject objectToPool_GRASS;
    public int amountToPool_GRASS;


    public List<GameObject> pooledList_KALLO;
    public GameObject objectToPool_KALLO;
    public int amountToPool_KALLO;


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
            pooledList_WATER.Add(tmp);
        }
        //------------------------

        //          LIHIS
        pooledList_LIHIS = new List<GameObject>();
        for (int i = 0; i < amountToPool_LIHIS; i++)
        {
            tmp = Instantiate(objectToPool_LIHIS);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_LIHIS.Add(tmp);
        }
        //------------------------

        //          LAVA
        pooledList_LAVA = new List<GameObject>();
        for (int i = 0; i < amountToPool_LAVA; i++)
        {
            tmp = Instantiate(objectToPool_LAVA);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_LAVA.Add(tmp);
        }
        //------------------------

        //          CLOUD
        pooledList_CLOUD = new List<GameObject>();
        for (int i = 0; i < amountToPool_CLOUD; i++)
        {
            tmp = Instantiate(objectToPool_CLOUD);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_CLOUD.Add(tmp);
        }
        //------------------------

        //          STEAM
        pooledList_STEAM = new List<GameObject>();
        for (int i = 0; i < amountToPool_STEAM; i++)
        {
            tmp = Instantiate(objectToPool_STEAM);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_STEAM.Add(tmp);
        }
        //------------------------

        //          GRASS
        pooledList_GRASS = new List<GameObject>();
        for (int i = 0; i < amountToPool_GRASS; i++)
        {
            tmp = Instantiate(objectToPool_GRASS);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_GRASS.Add(tmp);
        }
        //------------------------

        //          KALLO
        pooledList_KALLO = new List<GameObject>();
        for (int i = 0; i < amountToPool_KALLO; i++)
        {
            tmp = Instantiate(objectToPool_KALLO);
            tmp.GetComponent<SPAWNABLE>().SetPlanet(planet);
            tmp.SetActive(false);
            pooledList_KALLO.Add(tmp);
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

    public GameObject GetPooled_LIHIS()
    {
        for (int i = 0; i < amountToPool_LIHIS; i++)
        {
            if (!pooledList_LIHIS[i].activeInHierarchy)
            {
                return pooledList_LIHIS[i];
            }
        }
        return null;
    }

    public GameObject GetPooled_LAVA()
    {
        for (int i = 0; i < amountToPool_LAVA; i++)
        {
            if (!pooledList_LAVA[i].activeInHierarchy)
            {
                return pooledList_LAVA[i];
            }
        }
        return null;
    }

    public GameObject GetPooled_CLOUD()
    {
        for (int i = 0; i < amountToPool_CLOUD; i++)
        {
            if (!pooledList_CLOUD[i].activeInHierarchy)
            {
                return pooledList_CLOUD[i];
            }
        }
        return null;
    }

    public GameObject GetPooled_STEAM()
    {
        for (int i = 0; i < amountToPool_STEAM; i++)
        {
            if (!pooledList_STEAM[i].activeInHierarchy)
            {
                return pooledList_STEAM[i];
            }
        }
        return null;
    }


    public GameObject GetPooled_GRASS()
    {
        for (int i = 0; i < amountToPool_GRASS; i++)
        {
            if (!pooledList_GRASS[i].activeInHierarchy)
            {
                return pooledList_GRASS[i];
            }
        }
        return null;
    }


    public GameObject GetPooled_KALLO()
    {
        for (int i = 0; i < amountToPool_KALLO; i++)
        {
            if (!pooledList_KALLO[i].activeInHierarchy)
            {
                return pooledList_KALLO[i];
            }
        }
        return null;
    }

}
