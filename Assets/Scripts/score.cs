using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : playerMovement
{

    public Text scoreText;
    public Text bonesText;

    public float scoreAmount = 0.0f;
    public float scoreMultiplier = 0.000001f;
    public float playerSpeed = 1.0f;
    public float speedIncrease = 0.0f;
    public float scoreMultiplierFactor = 0.1f;
    public float difficultyMultiplier = 1.0f;
    public float speedAmount = 5.0f;
    private bool isAlive = true;
    public static float bonesAmount = 0.0f;
    public float newScore;

    private float doubleAt = 10.0f;

    public deathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "test";
        scoreAmount = 0.0f;
        characterSpeedForward = 2.0f;
        bonesAmount = 0.0f;
        newScore = 0.0f;

        
    }

    // Update is called once per frame
    void Update()
    { 
        if (!isAlive)
            return;
        // scoreAmount = scoreAmount + scoreMultiplier * characterSpeed;
        scoreAmount += Time.deltaTime; // * difficultyMultiplier;

        // Debug.Log(scoreAmount + "Score Amount");
        Debug.Log(characterSpeedForward + " SPEED");

        if(scoreAmount >= doubleAt) // speed increases everytime the score doubes
        {
            difficultyMultiplier += 0.2f;
            doubleAt = doubleAt + 10.0f;
            //addToSpeedZ(getSpeedZ() + speedAmount);
            characterSpeedForward += 0.5f;
            Debug.Log("TEST --- SPEED DOUBLES --- TEST");
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
        scoreText.text = "Score: " + ((int)scoreAmount).ToString();
        bonesText.text = "Bones: " + ((int)bonesAmount).ToString();
    }

    public void death()
    {
        //stop adding points to the score
        isAlive = false;
        deathMenu.toggleDeathMenu(scoreAmount, bonesAmount);
    }
}
