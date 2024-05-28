using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SublevelController : MonoBehaviour
{
    [SerializeField] private Button backButton;

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
        backButton.onClick.AddListener(() => GameManager.Instance.LoadScene("LevelScene", true));
    }
}
