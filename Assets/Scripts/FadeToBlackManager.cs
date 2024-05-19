using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlackManager : MonoBehaviour
{
    [SerializeField] private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.fadeToBlackScreen = gameObject;
        gameObject.SetActive(isActive);
    }
}
