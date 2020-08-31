using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Pipe" || col.tag == "Pipeblank")
            Destroy(col.gameObject.transform.parent.gameObject); //free up some memory
    }
}
