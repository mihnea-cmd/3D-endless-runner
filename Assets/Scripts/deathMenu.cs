using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class deathMenu : MonoBehaviour
{

    public Text scoreText;
    public Text bonesText2;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDeathMenu(float score, float bones)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + ((int)score).ToString();
        bonesText2.text = "Bones: " + ((int)bones).ToString();
    }

    public void restart()
    {
        SceneManager.LoadScene("scene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
