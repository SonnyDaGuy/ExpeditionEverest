using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCornerHUD : MonoBehaviour
{
    //public varible for binding button
    public Button MainMenuButton;
    public Button PauseButton;
    public Button RestartButton;
    private bool IsPause;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        MainMenuButton.onClick.AddListener(LoadMainMenu);
        PauseButton.onClick.AddListener(PauseFunction);
        RestartButton.onClick.AddListener(Restart);
;    }

    public void PauseFunction() {
        if (IsPause)
        {
            IsPause = false;
            Time.timeScale = 1;
        }
        else {
            IsPause = true;
            Time.timeScale = 0;
        }
    }

    public void LoadMainMenu() {
        //change the number later
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
