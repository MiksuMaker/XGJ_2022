using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWNABLE : MonoBehaviour
{

    public Planet planet;
    public int ListPos = 0;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetPlanet(Planet pla)
    {
        this.planet = pla;
    }



    public void SetListPos(int _pos)
    {
        //while(_pos < 0) { _pos += planet.GetListLength(); }
        ListPos = _pos;
    }


    public Vector3 CalculateAngle(int _pos)
    {
        float desiredAngle = _pos * (360 / this.planet.GetListLength());
        return new Vector3(0, 0, (desiredAngle - 90f + this.planet.GetEulerAngles()));
    }

}
