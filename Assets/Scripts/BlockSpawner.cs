using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;

    public static GameObject currentBlock;

    // Start is called before the first frame update
    void Start()
    {
        currentBlock = Instantiate(blocks[Random.Range(0, blocks.Length)],
                                   transform.position,
                                   Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {

        }
    }
}
