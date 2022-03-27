using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EYE_SCRIPT : MonoBehaviour
{

    [SerializeField] SpriteRenderer sr;
    [SerializeField] MeteoriteManager mete;
    [SerializeField] Sprite image1;
    [SerializeField] Sprite image2;
    [SerializeField] Sprite image3;
    [SerializeField] FadeOut fader;

    enum EYE_STATES
    {
        begin,
        waitToGoOut,
        goOut,
        waitToReappear,
        Appear,
        waitToClick
    }

    EYE_STATES state = EYE_STATES.begin;
    bool moveOn = false;
    bool clicked = false;

    int curFrame = 0;



    private void Update()
    {
        switch (state)
        {

            case EYE_STATES.begin:
                if (clicked)
                {
                    StartCoroutine(GoAnimation(1f, false));
                    moveOn = false;
                    state = EYE_STATES.waitToGoOut;
                }
                break;


            case EYE_STATES.waitToGoOut:
                    if (moveOn)
                {

                    StartCoroutine(GoAnimation(1f, true));
                    if (fader.gameObject.activeSelf)
                    {
                        fader.startFade();
                        mete.startBehaviour();
                    }
                    state = EYE_STATES.goOut;
                    moveOn = false;
                }
                break;


            case EYE_STATES.goOut:
                if (moveOn)
                {
                    sr.color = new Color(1, 1, 1, sr.color.a - Time.deltaTime * 1);
                    if (sr.color.a <= 0)
                    {
                        sr.color = new Color(1, 1, 1, 0);
                        state = EYE_STATES.waitToReappear;
                        StartCoroutine(WaitAppear(10f));
                    }
                }
                break;



            case EYE_STATES.waitToReappear:
                break;



            case EYE_STATES.Appear:
                sr.color = new Color(1, 1, 1, sr.color.a + Time.deltaTime * 1);
                if (sr.color.a >= 1)
                {
                    sr.color = new Color(1, 1, 1, 1);
                    state = EYE_STATES.waitToClick;
                }
                break;

            case EYE_STATES.waitToClick:
                if (clicked)
                {
                    StartCoroutine(GoAnimation(1f, false));
                    moveOn = false;
                    state = EYE_STATES.waitToGoOut;
                }
                break;

        }


    }



    private void OnMouseDown()
    {
        clicked = true;

    }



    IEnumerator WaitAppear(float time)
    {
        yield return new WaitForSeconds(time);
        state = EYE_STATES.Appear;
    }


    IEnumerator GoAnimation(float time, bool reversed)
    {

        yield return new WaitForSeconds(time);

        if (!reversed) { curFrame++; } else { curFrame--; }


        switch (curFrame)
        {
            case 0: sr.sprite = image1; StartCoroutine(GoAnimation(time, reversed)); break;
            case 1: sr.sprite = image2; StartCoroutine(GoAnimation(time, reversed)); break;
            case 2: sr.sprite = image3; StartCoroutine(GoAnimation(time, reversed)); break;
            default: moveOn = true; break;
        }


    }


}
