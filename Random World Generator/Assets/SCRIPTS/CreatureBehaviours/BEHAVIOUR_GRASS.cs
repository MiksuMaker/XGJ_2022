using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEHAVIOUR_GRASS : SPAWNABLE
{

    float countdown = 0f;

    [SerializeField] SpriteRenderer spr;
    [SerializeField] Sprite level1;
    [SerializeField] Sprite level2;
    [SerializeField] Sprite level3;

    int level = 0;

    private void OnEnable()
    {
        level = 0;
        setLevel(0);
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

}
