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
        UpdateStar();
        OnClickGameScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateStar()
    {
        if (SaveManager.GetClearedStatus(setting.level, setting.id))
        {
            transform.Find("Star_Outline").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("Star_Filled").gameObject.SetActive(false);
        }
    }

    private void OnClickGameScene()
    {
        stageButton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        stageButton.onClick.AddListener(() => GameManager.Instance.LoadStage(setting));
    }
}
