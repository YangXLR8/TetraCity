using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinController : MonoBehaviour
{
    [SerializeField] private Button backButtton;
    [SerializeField] private Button nextButtton;
    [SerializeField] private Button restartButtton;

    // Start is called before the first frame update
    void Start()
    {
        OnClickLevelScene();
        OnClickSublevelScene();
        OnClickRestartScene();

        GameManager.gameWinUI = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickLevelScene()
    {
        backButtton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        backButtton.onClick.AddListener(() => GameManager.Instance.LoadScene("LevelScene", true));
    }

    void OnClickSublevelScene()
    {
        nextButtton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        nextButtton.onClick.AddListener(() => GameManager.Instance.LoadScene($"SublevelScene_{GameManager.setting.level}", true));
    }

    void OnClickRestartScene()
    {
        restartButtton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        restartButtton.onClick.AddListener(() => GameManager.Instance.LoadStage(GameManager.setting));
    }
}
