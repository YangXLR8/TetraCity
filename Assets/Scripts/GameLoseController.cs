using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoseController : MonoBehaviour
{
    [SerializeField] private Button backButtton;
    [SerializeField] private Button restartButtton;

    // Start is called before the first frame update
    void Start()
    {
        OnClickLevelScene();
        OnClickRestartScene();

        GameManager.gameLoseUI = gameObject;
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

    void OnClickRestartScene()
    {
        restartButtton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        restartButtton.onClick.AddListener(() => GameManager.Instance.LoadStage(GameManager.setting));
    }
}
