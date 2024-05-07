using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Anchors")]
    [SerializeField] private GameObject clawObject;


    [Header("Offsets")]
    [SerializeField] private float offsetToTallest;
    [SerializeField] private float smoothTime;

    private Vector3 currentVelocity;
    private Vector3 targetPosition;

    private GameObject cameraObject;

    void Start()
    {
        cameraObject = GameObject.Find("Game Camera");
        targetPosition = cameraObject.transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {
        float offset = offsetToTallest - (clawObject.transform.position.y - BlockSpawner.FindTallest());
        if (offset > 0)
        {
            targetPosition += offset * Vector3.up;
        }
        print(cameraObject.transform.position.y);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraObject.transform.position = Vector3.SmoothDamp(cameraObject.transform.position, targetPosition, ref currentVelocity, smoothTime * Time.deltaTime);
    }
}
