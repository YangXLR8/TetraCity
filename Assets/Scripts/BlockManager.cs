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
            BlockSpawner.isBlockDropped = false;
            BlockSpawner.isBlockSpawned = false;

            BlockSpawner.SaveBlock();
            isDropped = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
