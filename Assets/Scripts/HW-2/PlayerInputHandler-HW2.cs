using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandlerHw2 : MonoBehaviour
{
    [SerializeField] DiscreteMovementHw2 playerCreature;
    private bool wPressed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // moved to Update so that character movement snaps, and input always captured
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerCreature.DiscreteMove(new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerCreature.DiscreteMove(new Vector3(0, -1, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerCreature.DiscreteMove(new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerCreature.DiscreteMove(new Vector3(1, 0, 0));
        }
    }
}
