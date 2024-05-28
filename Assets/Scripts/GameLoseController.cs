using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameLoseUI = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
