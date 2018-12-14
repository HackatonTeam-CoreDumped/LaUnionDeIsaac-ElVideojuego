﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject resumeButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("1Start");
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("2Login");
        Time.timeScale = 1f;
    }

    public void Selector()
    {
        SceneManager.LoadScene("3Selector");
        Time.timeScale = 1f;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("5Scene");
        Time.timeScale = 1f;
    }

    public void Score()
    {
        SceneManager.LoadScene("6Scoreboard");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        resumeButton.GetComponent<PauseMenu>().Score();
    }
}
