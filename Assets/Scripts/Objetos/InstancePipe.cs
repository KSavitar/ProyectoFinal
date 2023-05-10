using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePipe : MonoBehaviour
{
    public GameObject pipe;
    public PlayerController pipes;

    public void Instancepipe()
    {
        if (pipes.pipes >= 1)
        {
            Instantiate(pipe, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f), Quaternion.identity);
            pipes.pipes -= 1;
            Destroy(gameObject);
        }
    }
}
