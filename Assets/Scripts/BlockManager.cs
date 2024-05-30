using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    private bool isDropped = false;
    private bool isSfxPlayed = false;

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
                SoundManager.Instance.PlaySfx("BlockImpact");
                isSfxPlayed = true;

                BlockSpawner.SaveBlock();
                BlockSpawner.FreezeBlocks();

                GameManager.GameWin();
            }
            else 
            {
                GameManager.GameLose();
                
                isDropped = true;
            }
        }
        if (isDropped && !isSfxPlayed)
        {
            SoundManager.Instance.PlaySfx("BlockImpact");

            isSfxPlayed = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            SoundManager.Instance.PlaySfx("BlockImpact");
            isSfxPlayed = true;
            
            BlockSpawner.FreezeBlocks();
            GameManager.GameLose();
        }
    }
}
