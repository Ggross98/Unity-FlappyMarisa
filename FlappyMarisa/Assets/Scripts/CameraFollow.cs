using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    private Camera camera;

    float cameraZ;

    void Start()
    {
        camera = GetComponent<Camera>();
        cameraZ = camera.transform.position.z;
    }

   

    void Update()
    {
        camera.transform.position = new Vector3(Player.position.x + 0.8f, 0, cameraZ);

    }


    
}
