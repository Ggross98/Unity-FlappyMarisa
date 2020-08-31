using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    float posX=8.36f, posY=-2, posZ;

    void Awake()
    {
        //posX = transform.localPosition.x;
        //posY = transform.localPosition.y;
        posZ = transform.localPosition.z;

    }

    private void ResetPosition()
    {
        transform.localPosition = new Vector3(posX ,posY ,posZ );
    }
    
    void Update()
    {
        if (transform.localPosition.x < -8.36f)
        {
            ResetPosition();
        }
        transform.Translate(-Time.deltaTime,0,0);
    }
}
