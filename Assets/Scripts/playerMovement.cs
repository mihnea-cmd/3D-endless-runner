using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour

    
{
    public CharacterController controller;
    public float characterSpeed = 6.0f;
    public static float characterSpeedForward = 2.0f;

    private float gravity = 9.8f;
    private float verticalVelocity = 0.0f;

    //private bool isAlive = true;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
    controller = GetComponent<CharacterController>();
    }

    public float getSpeedZ()
    {
        return characterSpeedForward;
    }

    public void addToSpeedZ(float amount)
    {
        characterSpeedForward = characterSpeedForward + amount;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {
            Debug.Log("collision!");
            //isAlive = false;
            GetComponent<score>().death();
        }


    }

    public bool getLifeData()
    {
        //return isAlive;
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if(controller.isGrounded) // on the floor
        {
           // Debug.Log("GROUNDED ");
            verticalVelocity = 0.0f; 
        }
        else
        {
            verticalVelocity = verticalVelocity - gravity * Time.deltaTime;
        }
        moveVector.x = Input.GetAxis("Horizontal") * characterSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = characterSpeedForward;

        // controller.Move((Vector3.forward * characterSpeed) * Time.deltaTime);

        controller.Move(moveVector * Time.deltaTime);

    }
}
