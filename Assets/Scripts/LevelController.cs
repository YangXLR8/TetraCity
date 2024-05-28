using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickMenuScene()
    {
        foreach (Button button in buttons)
        {
            // Button homeScene = homeButton.GetComponent<Button>();
            // homeScene.onClick.AddListener(() => GameManager.Instance.LoadScene("MenuScene", true));
        }
    }
}
