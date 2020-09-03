using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, -2, -2);

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset.x = 0;
        offset.y = 2;
        offset.z = -4;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = playerTransform.position + offset;
        moveVector.x = 0;

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // start animation
            // linear interpolation
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition = transition + 0.01f;
        }
    }
}
