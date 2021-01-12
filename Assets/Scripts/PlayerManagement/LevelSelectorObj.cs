using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorObj : MonoBehaviour
{
    public int scene;
    private void OnMouseOver()
    {
        //highlight on

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void OnMouseExit()
    {
        //highlight off
    }
}
