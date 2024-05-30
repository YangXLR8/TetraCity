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
    [SerializeField] private float cameraSmoothTime;

    private Vector3 clawCurrentVelocity;
    private Vector3 clawTargetPosition;

    private Vector3 cameraCurrentVelocity;
    private Vector3 cameraTargetPosition;

    private GameObject cameraObject;

    private int direction = 1;
    private float baseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBgm("Game");

        cameraObject = GameObject.Find("Game Camera");

        cameraTargetPosition = cameraObject.transform.position;
        clawTargetPosition = transform.position;

        baseSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
         // If inputmanager drop button is pressed
        if (Input.GetButtonDown("Drop") && BlockSpawner.isBlockDropped == false && !GameManager.isGameOver && !GameManager.isTutorial)
        {
            BlockSpawner.DropBlock();
        }

        // If inputmanager stash buttons are pressed
        if (Input.GetButtonDown("Stash") && !BlockSpawner.isLastBlock)
        {
            if (BlockSpawner.isBlockSpawned && !BlockSpawner.isBlockDropped && !GameManager.isGameOver)
            {
                BlockSpawner.StashBlock();
            }
        }

        // If inputmanager rotate buttons are pressed
        if (Input.GetButtonDown("Rotate") && !BlockSpawner.isLastBlock)
        {
            if (BlockSpawner.isBlockSpawned && !BlockSpawner.isBlockDropped && !GameManager.isGameOver)
            {
                BlockSpawner.RotateBlock();
            }
        }

        AdjustClaw();
        AdjustSpeed();
        MoveClaw();
    }

    private void LateUpdate()
    {
        cameraObject.transform.position = Vector3.SmoothDamp(cameraObject.transform.position, 
                                                             cameraTargetPosition, 
                                                             ref cameraCurrentVelocity, 
                                                             cameraSmoothTime * Time.deltaTime);
    }

    private void AdjustClaw()
    {
        float offset = offsetToTallest - (transform.position.y - BlockSpawner.FindTallest());
        if (offset != 0)
        {
            transform.position += Vector3.up * offset;
            cameraTargetPosition += offset * Vector3.up;
        }
    }

    private void AdjustSpeed()
    {
        if (BlockSpawner.FindTallest() < 5) moveSpeed = baseSpeed * 1.3f;
        else if (BlockSpawner.FindTallest() < 10) moveSpeed = baseSpeed * 1.6f;
        else if (BlockSpawner.FindTallest() < 15) moveSpeed = baseSpeed * 2f;
    }

    private void MoveClaw()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime * direction;
        if (transform.position.x <= leftLimit) direction = 1;
        else if (transform.position.x >= rightLimit) direction = -1;
    }
}
