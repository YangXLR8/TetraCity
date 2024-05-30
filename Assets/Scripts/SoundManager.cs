using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    # region singleton
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get 
        {
            // instance already exists -> return it right away
            if(_instance) return _instance;

            // look in the scene for one
            _instance = FindObjectOfType<SoundManager>();

            // found one -> return it
            if(_instance) return _instance;

            // otherwise create a new one from scratch
            _instance = new GameObject(nameof(SoundManager), typeof(AudioSource)).AddComponent<SoundManager>();

            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;

        // lazy initialization of AudioSource component
        if(!audioSource) 
        {
            if(!TryGetComponent(out audioSource))
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
    }

    #endregion

    [SerializeField] private AudioClip sfxButtonClick;
    [SerializeField] private AudioClip sfxBlockImpact;
    
    [SerializeField] private AudioClip bgmMain;
    [SerializeField] private AudioClip bgmGame;

    [SerializeField] private AudioSource audioSource;  
    private static string currentBgm = ""; 

    public void PlaySfx(string clip)
    {
        if (clip.Equals("ButtonClick"))
        {
            audioSource.PlayOneShot(sfxButtonClick, 1);
        }
        if (clip.Equals("BlockImpact"))
        {
            audioSource.PlayOneShot(sfxBlockImpact, 1);
        }
    }

    public void PlayBgm(string clip)
    {
        if (clip.Equals("Main") && !currentBgm.Equals("Main"))
        {
            audioSource.Stop();

            audioSource.clip = bgmMain;
            audioSource.loop = true;
            audioSource.Play();

            currentBgm = "Main";
        }
        else if (clip.Equals("Game") && !currentBgm.Equals("Game"))
        {
            audioSource.Stop();

            audioSource.clip = bgmGame;
            audioSource.loop = true;
            audioSource.Play();

            currentBgm = "Game";
        }
    }

    IEnumerator FadeOut() 
    {
        float timeElapsed = 0;

        while (audioSource.volume > 0) 
        {
            audioSource.volume = Mathf.Lerp(1f, 0, timeElapsed / 0.5f);
            timeElapsed += Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator FadeIn() 
    {
        float timeElapsed = 0;

        while (audioSource.volume < 1) 
        {
            audioSource.volume = Mathf.Lerp(0, 1f, timeElapsed / 0.5f);
            timeElapsed += Time.deltaTime;
            yield return 0;
        }
}
}
