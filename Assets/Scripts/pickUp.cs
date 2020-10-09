using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : score

{

    private float distance;
    private float minDistance;
    private Transform playerTransform;
    private AudioSource source;
    private bool bonesIncreased = false;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        minDistance = 1.0f;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance <= minDistance)
        {
            source.Play();
            GetComponent<MeshRenderer>().enabled = false;
            if (!bonesIncreased)
            {
                bonesAmount = bonesAmount + 1.0f;
                bonesIncreased = true;
            }

        }
    }
}
