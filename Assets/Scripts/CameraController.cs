using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Offsets")]
    [SerializeField] private GameObject claw;
    [SerializeField] private float offsetToTallest;
    [SerializeField] private float smoothTime;

    private Vector3 currentVelocity;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {
        float offset = offsetToTallest - (claw.transform.position.y - BlockSpawner.FindTallest());
        if (offset > 0)
        {
            targetPosition += offset * Vector3.up;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime * Time.deltaTime);
    }
}
