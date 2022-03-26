using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_VEGE : SPAWNABLE
{


    enum VEGE_BEHA
    {
        set_start_pos,
        get_wander_pos,
        wander,
        eat,
        stop,
        hide
    }

    VEGE_BEHA beha = VEGE_BEHA.wander;

    [SerializeField] float curPos = 0;
    [SerializeField] int gotoPos = 10;
    [SerializeField] int movePos;

    private int ListLen;




    private void OnEnable()
    {
        beha = VEGE_BEHA.set_start_pos;
 
    }

    // Update is called once per frame
    void Update()
    {
        switch (beha)
        {
            case VEGE_BEHA.set_start_pos:
                curPos = ListPos;
                beha = VEGE_BEHA.get_wander_pos;
                break;

            case VEGE_BEHA.get_wander_pos:

                gotoPos = Mathf.RoundToInt(curPos) + Random.Range(-5, 5);
                switch (planet.GetPosType(gotoPos))
                {
                    default: beha = VEGE_BEHA.wander; break;

                    case TYPETYPE.types.LAVA: break;

                }
                break;
            case VEGE_BEHA.wander:


                SetPosition(curPos);
                curPos = Mathf.MoveTowards(curPos, gotoPos, .01f);
                if (curPos == gotoPos) { beha = VEGE_BEHA.stop; StartCoroutine(WaitAndSwitch(2f, VEGE_BEHA.get_wander_pos)); }

                break;
            case VEGE_BEHA.stop:
                SetPosition(curPos);
                break;
        }
    }



    IEnumerator WaitAndSwitch(float sec, VEGE_BEHA beh)
    {
        yield return new WaitForSeconds(sec);
        beha = beh;
    }
   

    public void SetPosition(float posi)
    {
        float desiredAngle = posi * (360 / planet.GetListLength());
        transform.eulerAngles = new Vector3(0, 0, (desiredAngle - 90f + planet.GetEulerAngles()));
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("WW");

        TYPETYPE other = collision.gameObject.GetComponent<TYPETYPE>();
        if (other != null)
        {
            if (other.getType() == TYPETYPE.types.VEGE) { other.gameObject.GetComponent<BEHAVIOUR_VEGE>().Die(); }
        }
    }

    public void Die()
    {
        planet.ModifyAmount(TYPETYPE.types.VEGE, -1);
        gameObject.SetActive(false);
    }


}
