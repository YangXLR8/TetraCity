using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> blocks = new();

    public static List<GameObject> spawnedBlocks = new();

    public static GameObject currentBlock;

    public static bool isBlockSpawned = false;
    public static bool isBlockDropped = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBlockSpawned)
        {
            SpawnBlock();
        }

        
    }

    public static void SaveBlock()
    {
        spawnedBlocks.Add(currentBlock);
    }

    void SpawnBlock()
    {
        currentBlock = Instantiate(blocks[Random.Range(0, blocks.Count)],
                                   transform.position,
                                   transform.rotation);
        // currentBlock.transform.eulerAngles = Vector3.zero;
        currentBlock.transform.SetParent(transform, true);

        isBlockSpawned = true;
    }

    public static void DropBlock()
    {
        if (!isBlockDropped)
        {
            currentBlock.transform.SetParent(null);

            Rigidbody currentRb = currentBlock.GetComponent<Rigidbody>();
            currentRb.useGravity = true;

            isBlockDropped = true;
        }
    }

    public static float FindTallest()
    {
        float tallestY = 0;
        foreach (GameObject gameObject in BlockSpawner.spawnedBlocks)
        {
            if (tallestY < gameObject.transform.position.y)
            {
                tallestY = gameObject.transform.position.y;
            }
        }

        return tallestY;
    }
}
