using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModifier : MonoBehaviour
{
    [SerializeField] float yVelocity = -5f;
    [SerializeField] float gameSpeedModifier = 1f;
    [SerializeField] float randomForceModifier = 50f;

    Paddle thePaddle;
    Rigidbody2D myRigidBody2D;
    GameSession gameSession;
    Ball theBall;
    void Start()
    {
        thePaddle = FindObjectOfType<Paddle>();
        gameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myRigidBody2D.velocity = new Vector2(0f, yVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Triggered!");
            //DecreasePaddleSize();
            //DecreasePaddleSpeed();
            //IncreaseGameSpeed();
            IncreaseRandomForce();
        }

    }

    private void IncreaseRandomForce()
    {
        theBall.ChangeRandomForce(randomForceModifier);
        Destroy(gameObject);
    }

    private void IncreaseGameSpeed()
    {
        gameSession.ChangeGameSpeed(gameSpeedModifier);
        Destroy(gameObject);
    }

    private void DecreasePaddleSpeed()
    {
        thePaddle.ChangePaddleSpeed();
        Destroy(gameObject);
    }

    private void DecreasePaddleSize()
    {
        thePaddle.ChangePaddleSize(-1f);
        Destroy(gameObject);
    }


    
}
