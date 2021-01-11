using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //public varible for binding button
    public Button StartTask;
    public Button ExitTask;

    // Start is called before the first frame update
    void Start()
    {
        //set up and bind funtion to button
        Button StartButton = StartTask.GetComponent<Button>();
        Button ExitButton = ExitTask.GetComponent<Button>();
        StartButton.onClick.AddListener(StartGameEvent);
        ExitButton.onClick.AddListener(ExitGameEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGameEvent() 
    {
        SceneManager.LoadScene(1);
    }

    void ExitGameEvent()
    {
        Application.Quit();
    }
}
