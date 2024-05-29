using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] buttons;
    private void Awake()
    {
        int unlockecLevel = PlayerPrefs.GetInt("UnlockLevel", 1);
        for (int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockecLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId){
        string levelName = "Menu Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
