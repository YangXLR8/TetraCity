using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

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

    private void Awake()
    {
        _instance = this;
    }

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
}
