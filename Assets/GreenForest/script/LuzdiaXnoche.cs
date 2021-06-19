using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzdiaXnoche : MonoBehaviour
{
    public int rotationScale = 10;
    public float timeSpeed = 1;
    public float min, grados;
    
    // Update is called once per frame
    void Update()
    {
        min += timeSpeed * Time.deltaTime;
        if(min >= 1440){
            min = 0;
        }


        grados = min/4;
        this.transform.localEulerAngles = new Vector3(grados,-90f,0f);
        // this.transform.Rotate(rotationScale*Time.deltaTime,0,0);
    }
}
