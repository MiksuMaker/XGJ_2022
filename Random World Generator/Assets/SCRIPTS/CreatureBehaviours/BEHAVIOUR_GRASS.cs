using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_GRASS : SPAWNABLE
{

    [SerializeField] float countdown = 0f;

    [SerializeField] SpriteRenderer spr;
    [SerializeField] Sprite level1;
    [SerializeField] Sprite level2;
    [SerializeField] Sprite level3;

    int level = 0;

    private void OnEnable()
    {
     
        level = 0;
        countdown = 0f;
        setLevel(0);
      
    }


    private void Update()
    {
        countdown = Mathf.MoveTowards(countdown, 0, 1f * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (countdown > 0f) { return; }

        if (collision.GetComponent<TYPETYPE>())
        {
            if (collision.GetComponent<TYPETYPE>().getType() == TYPETYPE.types.RAIN)
            {
                countdown = 10f;
                LevelUp();
            }
        }




    }


    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                spr.sprite = level2;
                break;
            case 2:
                spr.sprite = level3;
                break;

        }
    }


    public void setLevel(int _level)
    {
        
        level = _level;
        switch (level)
        {
            case 0:
                spr.sprite = level1;
                break;
            case 1:
                spr.sprite = level2;
                break;
            case 2:
                spr.sprite = level3;
                break;
        }
    }


    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        planet.setPos(ListPos, null);
        gameObject.SetActive(false);



    }

}
