using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject roofBlock;

    public static List<GameObject> spawnedBlocks = new();

    public static GameObject currentBlock;
    public static GameObject stashedBlock;

    public static bool isBlockSpawned = false;
    public static bool isBlockDropped = false;
    public static bool isLastBlock = false;

    // [SerializeField] private List<GameObject> blocks = new();
    private List<GameObject> blocks = new();

    // Start is called before the first frame update
    void Start()
    {
        spawnedBlocks.Clear();
        currentBlock = null;
        stashedBlock = null;

        isBlockSpawned = false;
        isBlockDropped = false;
        isLastBlock = false;

        LoadBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBlockSpawned && !GameManager.isGameOver)
        {
            SpawnBlock();
        }
    }

    public static void SaveBlock()
    {
        spawnedBlocks.Add(currentBlock);
    }

    public static void RotateBlock()
    {
        Vector3 position = currentBlock.GetComponent<Renderer>().bounds.center;
        currentBlock.transform.RotateAround(position, new Vector3(0, 0, 90), -90);
    }

    public static void StashBlock()
    {
        if (stashedBlock == null)
        {
            stashedBlock = currentBlock;
            stashedBlock.SetActive(false);

            isBlockSpawned = false;
        }
        else
        {
            GameObject temp = currentBlock;
            temp.SetActive(false);

            currentBlock = stashedBlock;
            currentBlock.SetActive(true);

            stashedBlock = temp;
        }
    }

    void SpawnBlock()
    {
        if (FindTallest() > GameManager.setting.height)
        {
            currentBlock = Instantiate(roofBlock,
                                       transform.position,
                                       Quaternion.identity);
            isLastBlock = true;
        }
        else
        {
            currentBlock = Instantiate(blocks[UnityEngine.Random.Range(0, blocks.Count)],
                                       transform.position,
                                       Quaternion.identity);
        }
        
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
        foreach (GameObject gameObject in spawnedBlocks)
        {
            if (tallestY < gameObject.transform.position.y)
            {
                tallestY = gameObject.transform.position.y;
            }
        }

        return tallestY;
    }

    private void LoadBlocks()
    {
        for (int i = 0; i < GameManager.setting.blocks.Count; i++)
        {
            blocks.Add(GameManager.setting.blocks[i]);
        }
    }
}
