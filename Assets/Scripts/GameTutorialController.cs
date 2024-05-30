using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTutorialController : MonoBehaviour
{
    [SerializeField] private Button continueButtton;
    // Start is called before the first frame update
    void Start()
    {
        OnClickContinueScene();

        if (!GameManager.isTutorial) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickContinueScene()
    {
        continueButtton.onClick.AddListener(() => SoundManager.Instance.PlaySfx("ButtonClick"));
        continueButtton.onClick.AddListener(() => 
            {
                gameObject.SetActive(false);

                GameManager.isTutorial = false;
            }
        );
    }
}
