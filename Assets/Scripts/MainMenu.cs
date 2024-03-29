﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Quit() 
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
