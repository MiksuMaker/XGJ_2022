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



    [Header("SPAWNABLES")]
    [SerializeField] GameObject LAVA_;
    [SerializeField] GameObject WATER_;
    [SerializeField] GameObject LIHIS_;
    [SerializeField] GameObject VEGE_;
    [SerializeField] GameObject STEAM_;
    [SerializeField] GameObject CLOUD_;

    [SerializeField] int AMOUNT_VEGE = 0;
    [SerializeField] int AMOUNT_LIHIS = 0;
    [SerializeField] int AMOUNT_CLOUD = 0;



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

        pos = RoundPos(pos);
        return placeList[pos];
    }

    public TYPETYPE.types GetPosType(int pos)
    {

        pos = RoundPos(pos);
        if (GetPos(pos) != null){
            return placeList[pos].GetComponent<TYPETYPE>().getType();
        }
        else { return TYPETYPE.types.NONE; }
    }

    public int GetListLength()
    {
        return placeList.Count;
    }

    public void setPos(int pos, GameObject obj)
    {
        pos = RoundPos(pos);
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


    public void OtherCollision(GameObject collider)
    {
        DoCollisionEvent(collider);
    }

  public void OtherOtherCollision(GameObject collider, int pos)
    {

        pos = RoundPos(pos);

        ReactToImpact(collider, pos);
    }




    private int RoundPos(int _pos)
    {
        while (_pos < 0)
        {
            _pos += GetListLength();
            //Debug.Log(pos);
        }
        if (_pos >= GetListLength())
        {
            _pos = _pos % GetListLength();
        }

        return _pos;

    }


    private void DoCollisionEvent(GameObject collider)
    {


        AudioManager.AUMA.playSound(AudioManager.AUMA.soMETEORITE);

        // Calculate the angle between Planet and collider
        float angle = Mathf.Atan2(collider.transform.position.y - transform.position.y, collider.transform.position.x - transform.position.x) * 180 / Mathf.PI - transform.localEulerAngles.z;

        // Calculate the correct distance for the Instantiated GameObject
        //float planetRadius = 0.4f;

        int listAngle = Mathf.RoundToInt((angle  / 360) * GetListLength());

  

        // Destroy the Meteorite object
        //Destroy(collider);
        
        ReactToImpact(collider, listAngle);

    }


    public float GetEulerAngles()
    {
        return transform.localEulerAngles.z;
    }


    private void ReactToImpact(GameObject thing, int pos)
    {

        if (thing == null) { return; }

        GameObject _obj;

        while (pos < 0)
        {
            pos += GetListLength();
        }

        TYPETYPE.types _type = thing.GetComponent<TYPETYPE>().getType();
      
        thing.SetActive(false);

        if (GetPos(pos) == null)
        {
            _obj = InstantiateImpactObject(_type, pos);
            setPos(pos, _obj);

            //Debug.Log(GetPos(pos));
            return;
        }

        //Debug.Log(GetPosType(pos));


        switch (GetPosType(pos))
        {

            //-------------------------------------------------------------------------------
            case TYPETYPE.types.TREE:
                switch (_type)
                {
                    default:
                        #region
                        _obj = InstantiateImpactObject(_type, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, _obj);
                        #endregion
                        break;

                    case TYPETYPE.types.TREE:
                        #region

                        GetPos(pos).SetActive(false);
                        setPos(pos, null);

                        break;
                        #endregion

                    case TYPETYPE.types.LAVA:
                        #region

                        break;
                        #endregion
                }
                break;
            //-------------------------------------------------------------------------------
            case TYPETYPE.types.WATER:


                switch (_type)
                {

                    case TYPETYPE.types.GRASS: break;

                    default:
                        #region
                        _obj = InstantiateImpactObject(TYPETYPE.types.WATER, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, _obj);
                        
                        #endregion
                        break;

                    case TYPETYPE.types.LAVA:
                        #region

                        _obj = InstantiateImpactObject(TYPETYPE.types.STEAM, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, null);
                        //Debug.Log("LAVA-WATER");
                        #endregion
                        break;
                }
                break;
            //-------------------------------------------------------------------------------
            case TYPETYPE.types.LAVA:
                switch (_type)
                {

                    case TYPETYPE.types.GRASS: break;

                    default:
                        #region
                        _obj = InstantiateImpactObject(TYPETYPE.types.LAVA, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, _obj);
                        
                        #endregion
                        break;

                    case TYPETYPE.types.WATER:
                        #region
                       
                        _obj = InstantiateImpactObject(TYPETYPE.types.STEAM, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, null);
                        //Debug.Log("LAVA-WATER");
                        #endregion
                        break;
                }
                break;
            //-------------------------------------------------------------------------------
            case TYPETYPE.types.GRASS:
                switch (_type)
                {


                    case TYPETYPE.types.GRASS: break;

                    case TYPETYPE.types.FIRE: break;

                    default:
                        GetPos(pos).SetActive(false);
                        setPos(pos, null);
                        break;

                    case TYPETYPE.types.WATER:
                        if (GetPos(pos).GetComponent<BEHAVIOUR_GRASS>().getLevel() == 0)
                        {
                            GetPos(pos).GetComponent<BEHAVIOUR_GRASS>().LevelUp();
                        }
                        else
                        {
                            GetPos(pos).SetActive(false);
                            setPos(pos, null);
                        }

                        break;

                }
                break;
            //-------------------------------------------------------------------------------
            case TYPETYPE.types.LAND:
                switch (_type)
                {
                    case TYPETYPE.types.WATER:
                    case TYPETYPE.types.LAVA:
                        _obj = InstantiateImpactObject(TYPETYPE.types.STEAM, pos);
                        GetPos(pos).SetActive(false);
                        setPos(pos, null);
                        break;

                }
                break;

            //-------------------------------------------------------------------------------
            case TYPETYPE.types.CLOUD:
                switch (_type)
                {
                    default: break;

                }
                break;
        }

        return;
    }





    public GameObject InstantiateImpactObject(TYPETYPE.types tyyppi, int pos)
    {
        GameObject temp = null;
        GameObject thingy = null;
        switch (tyyppi)
        {
            case TYPETYPE.types.WATER: temp = WATER_; thingy = ObjectPool.SharedInstance.GetPooled_WATER(); break;
            case TYPETYPE.types.LAVA: temp = LAVA_; thingy = ObjectPool.SharedInstance.GetPooled_LAVA(); break;
            case TYPETYPE.types.LIHIS: temp = LIHIS_; thingy = ObjectPool.SharedInstance.GetPooled_LIHIS(); break;
            case TYPETYPE.types.VEGE: temp = VEGE_; thingy = ObjectPool.SharedInstance.GetPooled_VEGE(); break;
            case TYPETYPE.types.STEAM: temp = STEAM_; thingy = ObjectPool.SharedInstance.GetPooled_STEAM(); break;
            case TYPETYPE.types.CLOUD: temp = CLOUD_; thingy = ObjectPool.SharedInstance.GetPooled_CLOUD(); break;
            case TYPETYPE.types.GRASS: temp = CLOUD_; thingy = ObjectPool.SharedInstance.GetPooled_GRASS(); break;
        }

        if (temp != null && thingy != null)
        {

            //Debug.Log(tyyppi);
            float desiredAngle = pos * (360 / GetListLength());

            // Add something as a child on the Planet's surface
            //GameObject thingy = Instantiate(temp, transform.position, Quaternion.identity) as GameObject;


            thingy.transform.position = new Vector3(thingy.transform.position.x, thingy.transform.position.y, -1);
            // Turn the instantiated surface gameobject to the correct rotation
            thingy.transform.eulerAngles = new Vector3(0, 0, (desiredAngle - 90f + transform.localEulerAngles.z));

            //Debug.Log("PLANET: " + transform.eulerAngles.z);
            //Debug.Log("Thingy: " + thingy.transform.eulerAngles.z);

            // Make the Planet the Parent
            thingy.transform.parent = gameObject.transform;


            thingy.SetActive(true);

            thingy.GetComponent<SPAWNABLE>().SetListPos(pos);
            thingy.GetComponent<SPAWNABLE>().SetPlanet(this);

            return thingy;

        }

        return null;
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
            case TYPETYPE.types.CLOUD: return AMOUNT_CLOUD;
        }
    }

    public void ModifyAmount(TYPETYPE.types tyyppi, int add)
    {
        switch (tyyppi)
        {
            case TYPETYPE.types.LIHIS: AMOUNT_LIHIS += add; break;
            case TYPETYPE.types.VEGE: AMOUNT_VEGE += add; break;
            case TYPETYPE.types.CLOUD: AMOUNT_CLOUD += add; break;
        }
    }



}
