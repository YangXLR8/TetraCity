using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    # region singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("GameManager is null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        #if UNITY_STANDALONE
        Screen.SetResolution(540, 960, false);
        Screen.fullScreen = false;
        #endif
    }

    #endregion

    public void Start()
    {
        SaveManager.Read();
    }

    public static GameObject fadeToBlackScreen;

    private void FadeScene(Action<PlayableDirector> callback)
    {
        fadeToBlackScreen.SetActive(true);

        PlayableDirector transition = fadeToBlackScreen.GetComponent<PlayableDirector>();
        transition.stopped += callback;
        transition.Play();
    }

    public void LoadScene(string scene, bool isFade)
    {
        if (isFade)
        {
            FadeScene(
                (PlayableDirector dir) => 
                    { 
                        SceneManager.LoadScene(scene, LoadSceneMode.Single); 
                    }
            );
        }
        else
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single); 
        }
        
    }

    public static StageSetting setting = new();

    public void LoadStage(StageSetting stage)
    {
        isGameOver = false;
        setting = stage;

        FadeScene(
            (PlayableDirector dir) => 
                { 
                    SceneManager.LoadScene($"GameScene_{stage.level}", LoadSceneMode.Single); 
                }
        );
    }

    public static GameObject gameWinUI;
    public static GameObject gameLoseUI;

    public static bool isGameOver = false;

    public static void GameLose()
    {
        isGameOver = true;
        gameLoseUI.SetActive(true);
        fadeToBlackScreen.transform.SetParent(gameLoseUI.transform, false);
    }

    public static void GameWin()
    {
        SaveManager.SetClearedStatus(setting.level, setting.id, true);
        SaveManager.Save();

        isGameOver = true;
        gameWinUI.SetActive(true);
        fadeToBlackScreen.transform.SetParent(gameWinUI.transform, false);
    }
}
