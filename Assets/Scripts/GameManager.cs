using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    public static GameObject fadeToBlackScreen;

    private void Awake()
    {
        _instance = this;
    }

    private void FadeTransition(Action<PlayableDirector> callback)
    {
        fadeToBlackScreen.SetActive(true);

        PlayableDirector transition = fadeToBlackScreen.GetComponent<PlayableDirector>();
        transition.stopped += callback;
        transition.Play();
    }

    public void LoadScene(string scene)
    {
        FadeTransition(
            (PlayableDirector dir) => 
                { 
                    SceneManager.LoadScene(scene, LoadSceneMode.Single); 
                }
        );
    }  
}
