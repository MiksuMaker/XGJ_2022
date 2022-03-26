using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;

    private float startingRot;
        
    [SerializeField] float planetRadius = 0.4f;

    [SerializeField] GameObject TEST_OBJECT;

    [Header("Placement List")]
    [SerializeField] int placementAmount = 6;
    [SerializeField] List<GameObject> placeList = new List<GameObject> ();


    

    int AMOUNT_VEGE = 0;
    int AMOUNT_LIHIS = 0;



    void Start()
    {

        startingRot = transform.eulerAngles.z;


        for (int i = 0; i < placementAmount; i++)
        {
            placeList.Add(null);
        }
    }
    void Update()
    {
        RotatePlanet();
    }

    // LISTS

    public GameObject GetPos(int pos)
    {
        while (pos < 0)
        {
            pos += GetListLength();
            //Debug.Log(pos);
        }
        return placeList[pos];
    }

    public TYPETYPE.types GetPosType(int pos)
    {
        while (pos < 0)
        {
            pos += GetListLength();
            //Debug.Log(pos);
        }
        if (GetPos(pos) != null){
            return placeList[pos].GetComponent<TYPETYPE>().getType();
        }
        else { return TYPETYPE.types.NONE; }
    }

    public int GetListLength()
    {
        return placeList.Count;
    }

    public void setPos(int pos, GameObject obj = null)
    {
        while (pos < 0)
        {
            pos += GetListLength();
            //Debug.Log(pos);
        }
        placeList[pos] = obj;
    }

    public Vector3 getPosRotation(int pos)
    {
        if (placeList[pos] != null)
        {
            return placeList[pos].transform.eulerAngles;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }


    // ROTATION

    private void RotatePlanet()
    {
        // Turns the Planet around
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    // COLLISION

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name + " hit the Planet!");
        //Destroy(collision.gameObject);

        DoCollisionEvent(collision.gameObject);
    }


    private void DoCollisionEvent(GameObject collider)
    {
        // Calculate the angle between Planet and collider
        float angle = Mathf.Atan2(collider.transform.position.y - transform.position.y, collider.transform.position.x - transform.position.x) * 180 / Mathf.PI - transform.localEulerAngles.z;

        // Calculate the correct distance for the Instantiated GameObject
        //float planetRadius = 0.4f;

        int listAngle = Mathf.RoundToInt((angle  / 360) * GetListLength());

        
        
        float desiredAngle = listAngle * (360 / GetListLength());



        // Add something as a child on the Planet's surface
        GameObject thingy = Instantiate(TEST_OBJECT, transform.position, Quaternion.identity) as GameObject;


        thingy.transform.position = new Vector3(thingy.transform.position.x, thingy.transform.position.y, -1);
        // Turn the instantiated surface gameobject to the correct rotation
        thingy.transform.eulerAngles = new Vector3(0, 0, (desiredAngle - 90f + transform.localEulerAngles.z));

        //Debug.Log("PLANET: " + transform.eulerAngles.z);
        //Debug.Log("Thingy: " + thingy.transform.eulerAngles.z);

        // Make the Planet the Parent
        thingy.transform.parent = gameObject.transform;


        thingy.GetComponent<SPAWNABLE>().SetListPos(listAngle);
        thingy.GetComponent<SPAWNABLE>().SetPlanet(this);

        // Destroy the Meteorite object
        //Destroy(collider);
        collider.SetActive(false);

        ReactToImpact(thingy, listAngle);

    }


    public float GetEulerAngles()
    {
        return transform.localEulerAngles.z;
    }


    private void ReactToImpact(GameObject thing, int pos)
    {
        while (pos < 0)
        {
            pos += GetListLength();
            //Debug.Log(pos);
        }

        TYPETYPE.types _type = thing.GetComponent<TYPETYPE>().getType();

        if (GetPos(pos) == null)
        {
            setPos(pos, thing);
            return;
        }



        switch (GetPosType(pos))
        {
            case TYPETYPE.types.TREE:
                switch (_type)
                {
                    case TYPETYPE.types.TREE:
                        #region

                        GetPos(pos).SetActive(false);
                        thing.SetActive(false);
                        setPos(pos, null);

                        break;
                        #endregion

                    case TYPETYPE.types.LAVA:
                        #region

                        break;
                        #endregion
                }
                break;
            


        }


    }




    private void EXAMPLE(GameObject collider)   // FOR REFERENCE ONLY ATM
    {
        // Calculate the angle between Planet and collider
        float angle = Mathf.Atan2(collider.transform.position.y - transform.position.y, collider.transform.position.x - transform.position.x) * 180 / Mathf.PI;

        // Calculate the correct distance for the Instantiated GameObject
        //float planetRadius = 0.4f;

        float debugAngle = Mathf.RoundToInt((angle / 360) * GetListLength());
        Debug.Log("DebugAngle: " + debugAngle);

        Vector2 desiredPos = transform.position;
        desiredPos = Vector2.MoveTowards(transform.position, collider.transform.position, planetRadius);

        //Debug.Log("DesiredPos: " + desiredPos);

        // Add something as a child on the Planet's surface
        //GameObject thingy = Instantiate(TEST_OBJECT, collider.transform.position, Quaternion.identity) as GameObject;
        GameObject thingy = Instantiate(TEST_OBJECT, desiredPos, Quaternion.identity) as GameObject;

        // Turn the instantiated surface gameobject to the correct rotation
        thingy.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        // Make the Planet the Parent
        thingy.transform.parent = gameObject.transform;


        // Destroy the Meteorite object
        //Destroy(collider);
        collider.SetActive(false);
    }


    public Vector3 GetRotation()
    {
        return transform.localEulerAngles;
    }



    public int GetAmount(TYPETYPE.types tyyppi)
    {
        switch (tyyppi)
        {
            default: return 0;
            case TYPETYPE.types.LIHIS: return AMOUNT_LIHIS;
            case TYPETYPE.types.VEGE: return AMOUNT_VEGE;
        }
    }

    public void ModifyAmount(TYPETYPE.types tyyppi, int add)
    {
        switch (tyyppi)
        {
            case TYPETYPE.types.LIHIS: AMOUNT_LIHIS += add; break;
            case TYPETYPE.types.VEGE: AMOUNT_VEGE += add; break;
        }
    }



}
