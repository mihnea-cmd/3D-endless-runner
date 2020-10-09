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
    private float jumpForce = 13.0f;
    private float jumpForceDefault = 13.0f;

    private float initialY;
    public bool isJumping = false;
    private float jumpStartTime;
    private float jumpEndTime;

    //private bool isAlive = true;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        initialY = transform.position.y;
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

    private void checkFallDeath()
    {
        if (transform.position.y < initialY - 20)
            GetComponent<score>().death();
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
            if (!isJumping)
            // Debug.Log("GROUNDED ");
            {
                verticalVelocity = 0.0f;
                moveVector.y = verticalVelocity;
            }
        }
        else
        {
            if (!isJumping)
            {
                verticalVelocity = verticalVelocity - gravity * Time.deltaTime;
                moveVector.y = verticalVelocity;
            }
        }
        moveVector.x = Input.GetAxis("Horizontal") * characterSpeed;
       
        moveVector.z = characterSpeedForward;

        // controller.Move((Vector3.forward * characterSpeed) * Time.deltaTime);


        checkFallDeath();

        if(Input.GetKeyDown("space"))
        {
            //moveVector.y = Input.GetAxis("Jump") * characterSpeed * 2;
           if (controller.isGrounded)
                if (!isJumping)
                {
                
                    isJumping = true;
                    jumpForce = jumpForceDefault;
                    jumpStartTime = Time.realtimeSinceStartup;
                    //      transform.Translate(Vector3.up * 100 * Time.deltaTime, Space.World);

                }
                    //GetComponent<Rigidbody>().AddForce(Vector3.up * 100);

            
        }

        if (isJumping)
        {
            jumpEndTime = Time.realtimeSinceStartup;

            //transform.Translate(Vector3.up * 30 * Time.deltaTime, Space.World);

            Debug.Log(jumpEndTime);

            // moveVector.y += 3.0f;
            verticalVelocity = verticalVelocity + jumpForce * Time.deltaTime;
            jumpForce -= 0.3f;
            moveVector.y = verticalVelocity;

            if (jumpEndTime - jumpStartTime > 0.5f)
                {
                isJumping = false;
                Debug.Log(jumpEndTime - jumpStartTime);
                }

            //isJumping = false;
        }

        if(!controller.isGrounded)
            if(!isJumping)
            {
                verticalVelocity = verticalVelocity - gravity * Time.deltaTime;
                moveVector.y = verticalVelocity;

            }

        controller.Move(moveVector * Time.deltaTime);


    

    }
}
