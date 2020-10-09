using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGame()
    {
        SceneManager.LoadScene("scene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void optionsMenu()
    {
        SceneManager.LoadScene("options");
    }

    public void loadInstructions()
    {
        SceneManager.LoadScene("instructions");
    }

    public void loadAbout()
    {
        SceneManager.LoadScene("about");
    }
}
