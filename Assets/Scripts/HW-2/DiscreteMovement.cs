using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovementHw2 : MonoBehaviour
{
    // Start is called before the first frame update; NOT a constructor
    void Start()
    {
    }

    // Update is called once per frame (runs continuously); be careful what you put in here!
    void Update()
    {
    }

    public void DiscreteMove(Vector3 movement)
    {
        // Calculate new position
        Vector3 newPosition = transform.position + movement;

        // Update the position
        transform.position = newPosition;
    }
}
