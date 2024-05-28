using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLevelController : MonoBehaviour
{
    [SerializeField] private Button homeButton;

    // Start is called before the first frame update
    void Start()
    {
        OnClickMenuScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickMenuScene()
    {
        Button homeScene = homeButton.GetComponent<Button>();
        homeScene.onClick.AddListener(() => GameManager.Instance.LoadScene("MenuScene", true));
    }
}
