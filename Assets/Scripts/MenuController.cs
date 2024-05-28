using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        OnClickChooseLevelsScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickChooseLevelsScene()
    {
        playButton.onClick.AddListener(() => GameManager.Instance.LoadScene("LevelScene", true));
    }
}
