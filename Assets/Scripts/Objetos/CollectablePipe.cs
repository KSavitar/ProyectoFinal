using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePipe : MonoBehaviour
{
    public PlayerController tubes;

    public void Interact()
    {
        tubes.pipes += 1;
        Destroy(gameObject);
    }
}
