using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYPETYPE : MonoBehaviour
{
  public enum types
    {
        TREE,LAVA,WATER,

        VEGE,LIHIS,

        NONE

    }

    [SerializeField] types this_type;

    public TYPETYPE.types getType()
    {
        return this_type;
    }
}
