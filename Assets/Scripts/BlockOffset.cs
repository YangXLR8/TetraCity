using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOffset : MonoBehaviour
{
    [SerializeField] private Quaternion rotateOffset;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = rotateOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
