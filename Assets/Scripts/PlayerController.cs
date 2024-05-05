using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         // If inputmanager drop button is pressed
        if (Input.GetButtonDown("Drop") && BlockSpawner.isBlockDropped == false)
        {
            BlockSpawner.DropBlock();
            BlockSpawner.isBlockDropped = true;
        }

        // If inputmanager horizontal negative buttons are pressed
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // AccessPreviousBlock();
        }

        // If inputmanager horizontal positive buttons are pressed
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // AccessNextBlock();
        }

        // If inputmanager stash buttons are pressed
        if (Input.GetButtonDown("Stash"))
        {
            // AccessStashedBlock();
        }

        // If inputmanager rotate buttons are pressed
        if (Input.GetButtonDown("Rotate"))
        {
            // RotateBlockClockwise();
        }

    }
}
