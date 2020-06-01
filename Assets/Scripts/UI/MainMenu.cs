﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionMenuObj;
    public GameObject MainMenuObj;

    public Sprite OptionWindowed;
    public Sprite OptionFullscreen;

   

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OptionMenuObj.SetActive(false);
        Screen.fullScreen = true;
        FindObjectOfType<AudioManager>().Play("Main Theme");
    }

    //private void Awake()
    //{
    //    FindObjectOfType<AudioManager>().Play("Main Theme");
    //}

    //Menu Principal
    public void Play()
    {
        SceneManager.LoadScene("Cinematic");
        FindObjectOfType<AudioManager>().StopPlaying("Main Theme");
    }

    public void Options()
    {
        OptionMenuObj.SetActive(true);
        MainMenuObj.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Menu Options
    public void BackMenu()
    {
        MainMenuObj.SetActive(true);
        OptionMenuObj.SetActive(false);
    }

    public void Windowed()
    {
        Debug.Log("windowed");
        Screen.fullScreen = false;
        OptionMenuObj.GetComponent<Image>().sprite = OptionWindowed;
    }

    public void Fullscreen()
    {
        Debug.Log("fullscreen");
        Screen.fullScreen = true;
        OptionMenuObj.GetComponent<Image>().sprite = OptionFullscreen;
    }
}
