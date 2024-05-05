using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground"))
        {
            BlockSpawner.isBlockDropped = false;
            BlockSpawner.isBlockSpawned = false;
        }
    }
}
