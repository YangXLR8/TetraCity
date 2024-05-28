using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] private StageSetting setting = new();
    [SerializeField] private Button stageButton;

    // Start is called before the first frame update
    void Start()
    {
        OnClickGameScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickGameScene()
    {
        stageButton.onClick.AddListener(() => GameManager.Instance.LoadStage(setting));
    }
}
