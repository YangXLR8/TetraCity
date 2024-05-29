using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    private bool isDropped = false;

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
        if (!other.gameObject.CompareTag("Ground") && !isDropped)
        {
            if (!BlockSpawner.isLastBlock)
            {
                BlockSpawner.isBlockDropped = false;
                BlockSpawner.isBlockSpawned = false;

                BlockSpawner.SaveBlock();
                isDropped = true;
            }
            else if (BlockSpawner.isLastBlock && other.gameObject.CompareTag("Block"))
            {
                BlockSpawner.SaveBlock();
                for (int i = 0; i < BlockSpawner.spawnedBlocks.Count; i++)
                {
                    Rigidbody rb = BlockSpawner.spawnedBlocks[i].GetComponent<Rigidbody>();

                    rb.isKinematic = false;
                    rb.useGravity = false;

                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.Sleep();
                }

                GameManager.GameWin();
            }
            else 
            {
                GameManager.GameLose();
            }
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            GameManager.GameLose();
        }
    }
}
