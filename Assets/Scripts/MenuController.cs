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
        Button playScene = playButton.GetComponent<Button>();
        playScene.onClick.AddListener(GameManager.Instance.LoadGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
