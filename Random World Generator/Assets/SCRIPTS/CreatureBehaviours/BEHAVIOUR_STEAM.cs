using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_STEAM : SPAWNABLE
{

    enum STEAM_BEHA
    {
        set_start_pos,
        fly,
        stop,
        cloud
    }

    STEAM_BEHA beha = STEAM_BEHA.stop;

    [SerializeField] float curPos = 0;
    [SerializeField] int gotoPos = 0;
    [SerializeField] int movePos;


    private int ListLen;


    private void OnEnable()
    {

        StopAllCoroutines();
        transform.position = Vector3.zero;
        beha = STEAM_BEHA.set_start_pos;
   
    }

    // Update is called once per frame
    void Update()
    {
        switch (beha)
        {
            case STEAM_BEHA.set_start_pos:
                curPos = ListPos;
                gotoPos = (int)curPos;
                beha = STEAM_BEHA.fly;
                StartCoroutine(WaitAndSwitch(2f, STEAM_BEHA.cloud));
                break;

      
            case STEAM_BEHA.fly:
                SetPosition(curPos);
                break;

            case STEAM_BEHA.stop:
                SetPosition(curPos);
                break;


            case STEAM_BEHA.cloud:
                if (planet.GetAmount(TYPETYPE.types.CLOUD) < 4)
                {
                    planet.ModifyAmount(TYPETYPE.types.CLOUD, 1);
                    planet.InstantiateImpactObject(TYPETYPE.types.CLOUD, ListPos);
                }
                gameObject.SetActive(false);
                break;
        }
    }



    IEnumerator WaitAndSwitch(float sec, STEAM_BEHA beh)
    {
        yield return new WaitForSeconds(sec);
        beha = beh;
    }


    public void SetPosition(float posi)
    {
        //transform.position += new Vector3(0, 0.1f*Time.deltaTime, 0);

        float desiredAngle = posi * (360 / planet.GetListLength());
        transform.eulerAngles = new Vector3(0, 0, (desiredAngle - 90f + planet.GetEulerAngles()));
    }



}
