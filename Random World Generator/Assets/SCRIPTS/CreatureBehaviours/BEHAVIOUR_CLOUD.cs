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

    private int ListLen;

    private float Countdown = 0f;
    [SerializeField] float CountdownSet = 10f;




    private void OnEnable()
    {
        beha = CLOUD_BEHA.set_start_pos;
        if (planet != null)
        {
            planet.ModifyAmount(TYPETYPE.types.VEGE, 1);
        }
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
        if (collision.gameObject == colli) { return; }

        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

        TYPETYPE other = collision.gameObject.GetComponent<TYPETYPE>();
        if (other != null)
        {
            if (other.getType() == TYPETYPE.types.CLOUD) {
                grassCreator.SetActive(true);
                Countdown = CountdownSet;
                planet.OtherCollision(grassCreator);
            }
        }
    }

    public void Die()
    {
        planet.ModifyAmount(TYPETYPE.types.VEGE, -1);
        gameObject.SetActive(false);
    }
}
