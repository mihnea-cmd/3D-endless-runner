using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fullscreenToggle()
    {
       Screen.fullScreen = !Screen.fullScreen;
    }

    public void resolution640x480()
    {
        if(Screen.fullScreen)
            Screen.SetResolution(640, 480, true);
        else
            Screen.SetResolution(640, 480, false);
    }

    public void resolution1280x720()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1280, 720, true);
        else
            Screen.SetResolution(1280, 720, false);
    }

    public void resolution1920x1080()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1920, 1080, true);
        else
            Screen.SetResolution(1920, 1080, false);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
