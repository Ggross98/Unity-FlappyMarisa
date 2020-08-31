using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float timeMin=1.5f, timeMax=2f;
    public float yMin=-0.5f, yMax=1f;
    public float xOffset = 1f;
    void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            float y = Random.Range(yMin , yMax );
            Vector3 position = new Vector3(transform.position.x+xOffset ,y,transform.position.z);
            GameObject newPipe = Instantiate(pipePrefab , position, Quaternion.identity) as GameObject;
        }
        float rate;
        if (Difficulty.instance == null)
        {
            rate = 1;
        }
        else
        {
            rate = Difficulty.instance.GetRate();
        }
        Invoke("Spawn", Random.Range(timeMin, timeMax)/rate);
    }
}
