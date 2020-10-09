using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleEffect : playerMovement

{

    private float distance;
    private float minDistance;
    private Transform playerTransform;
    private AudioSource source;
    private bool speedDecreased = false;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("AAA");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        minDistance = 0.5f;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("BBB");
        distance = Vector3.Distance(playerTransform.position, transform.position);


        if (distance <= minDistance)
        {
            source.Play();
            //Debug.Log("AAAAAAAAAAAAaaaa");
            GetComponent<MeshRenderer>().enabled = false;
            if (!speedDecreased)
            {
                characterSpeedForward -= 1.5f;
                speedDecreased = true;
            }

        }
    }
}
