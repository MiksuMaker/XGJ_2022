using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_LIHIS : SPAWNABLE
{

    enum VEGE_BEHA
    {
        set_start_pos,
        get_wander_pos,
        wander,
        hunt,
        eat,
        stop,
        hide
    }

    VEGE_BEHA beha = VEGE_BEHA.wander;

    [SerializeField] float curPos = 0;
    [SerializeField] int gotoPos = 10;
    [SerializeField] int movePos;

    [SerializeField] BEHAVIOUR_VEGE kohde;

    [SerializeField] Sprite deadSprite;

    Transform tr;

    private int ListLen;

    Coroutine Hungerco;

    // PArticles
    [SerializeField] ParticleMaker particle;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }


    private void OnEnable()
    {

        StopAllCoroutines();
        beha = VEGE_BEHA.set_start_pos;

        Hungerco = StartCoroutine(DieOfHunger(15f));
  
    }

    // Update is called once per frame
    void Update()
    {
        switch (beha)
        {
            case VEGE_BEHA.set_start_pos:

                // Particles
                particle.MakeParticles(0);

                curPos = ListPos;
                beha = VEGE_BEHA.get_wander_pos;
                break;

            case VEGE_BEHA.get_wander_pos:

                gotoPos = Mathf.RoundToInt(curPos) + Random.Range(-5, 5);

                if (gotoPos < curPos)
                {
                    tr.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    tr.localScale = new Vector3(1, 1, 1);
                }

                switch (planet.GetPosType(gotoPos))
                {
                    default: beha = VEGE_BEHA.wander; break;

                    case TYPETYPE.types.LAVA: case TYPETYPE.types.WATER: break;

                }
                break;
            case VEGE_BEHA.wander:


                SetPosition(curPos);
                curPos = Mathf.MoveTowards(curPos, gotoPos, 1f * Time.deltaTime);
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



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.activeSelf)
        {

            if (collision.gameObject.GetComponent<BEHAVIOUR_VEGE>())
            {


                AudioManager.AUMA.playSound(AudioManager.AUMA.soEAT);

                StopCoroutine(Hungerco);
                Hungerco = StartCoroutine(DieOfHunger(15f));

                collision.gameObject.GetComponent<BEHAVIOUR_VEGE>().Die();
            }
        }
    }



    IEnumerator DieOfHunger(float time)
    {
        yield return new WaitForSeconds(time);


        GameObject vege = ObjectPool.SharedInstance.GetPooled_KALLO();

        //now using pooler
        if (vege != null)
        {
            // We'll assign the correct values here cuz object pooling 
            vege.transform.position = transform.position;
            vege.transform.eulerAngles = transform.eulerAngles;
            vege.transform.parent = planet.transform;

            //vege.GetComponent<SpriteRenderer>().sprite = deadSprite;
            vege.SetActive(true);
        }

        planet.ModifyAmount(TYPETYPE.types.LIHIS, -1);
        gameObject.SetActive(false);



    }





    public override void Die()
    {

        GameObject vege = ObjectPool.SharedInstance.GetPooled_KALLO();

        //now using pooler
        if (vege != null)
        {
            // We'll assign the correct values here cuz object pooling 
            vege.transform.position = transform.position;
            vege.transform.eulerAngles = transform.eulerAngles;
            vege.transform.parent = planet.transform;
            //vege.GetComponent<SpriteRenderer>().sprite = deadSprite;

            vege.SetActive(true);
        }

        planet.ModifyAmount(TYPETYPE.types.LIHIS, -1);
        gameObject.SetActive(false);
    }

}
