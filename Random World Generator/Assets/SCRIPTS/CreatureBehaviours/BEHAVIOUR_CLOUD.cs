using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_CLOUD : SPAWNABLE
{

    enum CLOUD_BEHA
    {
        set_start_pos,
        get_wander_pos,
        wander,
        eat,
        stop,
        hide
    }

    CLOUD_BEHA beha = CLOUD_BEHA.wander;

    [SerializeField] float curPos = 0;
    [SerializeField] int gotoPos = 10;
    [SerializeField] int movePos;

    [SerializeField] GameObject grassCreator;
    [SerializeField] GameObject colli;
    [SerializeField] GameObject rain;

    private int ListLen;

    private float Countdown = 0f;
    [SerializeField] float CountdownSet = 10f;




    private void OnEnable()
    {
        beha = CLOUD_BEHA.set_start_pos;
        rain.SetActive(false);
        StartCoroutine(Dissapear(20f));

    }

    // Update is called once per frame
    void Update()
    {

        Countdown = Mathf.MoveTowards(Countdown, 0, .1f * Time.deltaTime);

        switch (beha)
        {
            case CLOUD_BEHA.set_start_pos:
                curPos = ListPos;
                beha = CLOUD_BEHA.get_wander_pos;
                break;

            case CLOUD_BEHA.get_wander_pos:

                gotoPos = Mathf.RoundToInt(curPos) + Random.Range(-5, 5);
                switch (planet.GetPosType(gotoPos))
                {
                    default: beha = CLOUD_BEHA.wander; break;

                    //case TYPETYPE.types.LAVA: break;

                }
                break;
            case CLOUD_BEHA.wander:


                SetPosition(curPos);
                curPos = Mathf.MoveTowards(curPos, gotoPos, .01f);
                if (curPos == gotoPos) { beha = CLOUD_BEHA.stop; StartCoroutine(WaitAndSwitch(2f, CLOUD_BEHA.get_wander_pos)); }

                break;
            case CLOUD_BEHA.stop:
                SetPosition(curPos);
                break;
        }
    }



    IEnumerator WaitAndSwitch(float sec, CLOUD_BEHA beh)
    {
        yield return new WaitForSeconds(sec);
        beha = beh;
    }


    public void SetPosition(float posi)
    {
        float desiredAngle = posi * (360 / planet.GetListLength());
        transform.eulerAngles = new Vector3(0, 0, (desiredAngle - 90f + planet.GetEulerAngles()));
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == colli || collision.gameObject == rain) { return; }

            if (rain.activeSelf == false)
            {
                rain.SetActive(true);
            }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == colli || collision.gameObject == rain) { return; }


        if (rain.activeSelf == true)
        {
            rain.SetActive(false);
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }


    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        planet.ModifyAmount(TYPETYPE.types.CLOUD, -1);
        gameObject.SetActive(false);



    }
}
