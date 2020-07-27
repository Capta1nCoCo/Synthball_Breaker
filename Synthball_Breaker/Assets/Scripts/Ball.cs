using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float yPush = 15f;
    [SerializeField] float xPush = 2f;
    [SerializeField] AudioClip[] hitSonds;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // references
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {        
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {               
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnSpaceButton();
        }             
    }

    private void LaunchOnSpaceButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {       
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = hitSonds[UnityEngine.Random.Range(0, hitSonds.Length)];
            audioSource.PlayOneShot(clip);
        }        
    }

}
