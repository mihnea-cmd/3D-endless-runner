using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : playerMovement
{

    public Text scoreText;
    public float scoreAmount = 0.0f;
    public float scoreMultiplier = 0.000001f;
    public float playerSpeed = 1.0f;
    public float speedIncrease = 10;
    public float scoreMultiplierFactor = 0.1f;
    public float difficultyMultiplier = 1.0f;
    public float speedAmount = 1.0f;
    private bool isAlive = true;

    public deathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "test";
        scoreAmount = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;
       // scoreAmount = scoreAmount + scoreMultiplier * characterSpeed;
       scoreAmount += Time.deltaTime * difficultyMultiplier;

        if(scoreAmount >= speedIncrease) // speed increases everytime the score doubes
        {
            difficultyMultiplier += 0.2f;
            speedIncrease = speedIncrease * 2;
            addToSpeedZ(getSpeedZ() + speedAmount);
        }
      /*  if(scoreAmount >= speedIncrease)
        {
            speedIncrease = scoreAmount * 10.0f;
            scoreMultiplier = scoreMultiplier * scoreMultiplierFactor;
            scoreMultiplierFactor = scoreMultiplierFactor + 0.01f;
            //characterSpeed = characterSpeed + 1.0f;
            addToSpeedZ(getSpeedZ() + 0.001f);
            Debug.Log("SPEED: " + characterSpeedForward);

        }*/
        scoreText.text = ((int)scoreAmount).ToString(); 
    }

    public void death()
    {
        //stop adding points to the score
        isAlive = false;
        deathMenu.toggleDeathMenu(scoreAmount);
    }
}
