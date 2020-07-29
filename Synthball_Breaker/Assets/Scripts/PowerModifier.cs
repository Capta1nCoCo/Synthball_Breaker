using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModifier : MonoBehaviour
{
    [SerializeField] float yVelocity = -5f;
    [SerializeField] float gameSpeedModifier = .2f;
    [SerializeField] float randomForceModifier = 20f;

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

            IncreaseRandomForce();
        }

    }

    // Power-Downs:
    private void IncreaseRandomForce()
    {
        theBall.ChangeRandomForce(randomForceModifier);
        Destroy(gameObject);
    }

    private void PowerDownGameSpeed()
    {
        gameSession.IncreaseGameSpeed(gameSpeedModifier);
        Destroy(gameObject);
    }

    private void PowerDownPaddleSpeed()
    {
        thePaddle.DecreasePaddleSpeed();
        Destroy(gameObject);
    }

    private void PowerDownPaddleSize()
    {
        thePaddle.ChangePaddleSize(-1f);
        Destroy(gameObject);
    }

    // Power-Ups:
    private void PowerUpPaddleSize()
    {
        thePaddle.ChangePaddleSize(2f);
        Destroy(gameObject);
    }

    private void PowerUpPaddleSpeed()
    {
        thePaddle.IncreasePaddleSpeed();
        Destroy(gameObject);
    }

    private void PowerUpGameSpeed()
    {
        gameSession.DecreaseGameSpeed(gameSpeedModifier);
        Destroy(gameObject);
    }
    
}
