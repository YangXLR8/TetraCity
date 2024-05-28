using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private List<Button> levelButtons = new();

    // Start is called before the first frame update
    void Start()
    {
        OnClickMenuScene();
        OnClickLevelScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickMenuScene()
    {
        homeButton.onClick.AddListener(() => GameManager.Instance.LoadScene("MenuScene", true));
    }

    void OnClickLevelScene()
    {
        levelButtons[0].onClick.AddListener(() => GameManager.Instance.LoadScene("SublevelScene_1", true));
        
        levelButtons[1].onClick.AddListener(() => GameManager.Instance.LoadScene("SublevelScene_2", true));
        // if (SaveManager.GetClearedStages("Level0") == 0)
        //     levelButtons[1].interactable = false;

        levelButtons[2].onClick.AddListener(() => GameManager.Instance.LoadScene("SublevelScene_3", true));
        // if (SaveManager.GetClearedStages("Level1") == 0)
        //     levelButtons[2].interactable = false;
    }
}
