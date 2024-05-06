using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float moveSpeed;

    [Header("Offsets")]
    [SerializeField] private float offsetToTallest;

    private int direction = 1;

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

        MoveClaw();
        AdjustClaw();
    }

    private void AdjustClaw()
    {
        float offset = offsetToTallest - (transform.position.y - BlockSpawner.FindTallest());
        if (offset > 0)
        {
            transform.position += Vector3.up * offset;
        }
    }

    private void MoveClaw()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime * direction;
        if (transform.position.x <= leftLimit) direction = 1;
        else if (transform.position.x >= rightLimit) direction = -1;
    }
}
