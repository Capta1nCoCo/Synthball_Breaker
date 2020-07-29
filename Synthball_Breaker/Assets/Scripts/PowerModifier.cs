using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModifier : MonoBehaviour
{
    [SerializeField] float yVelocity = -5f;
    [SerializeField] float gameSpeedModifier = .2f;
    [SerializeField] float randomForceModifier = 20f;
    [SerializeField] float sizeModifier = 1f;

    [Header("Power-Down Type")]
    [SerializeField] bool increaseGameSpeed;
    [SerializeField] bool decreasePaddleSize;
    [SerializeField] bool decreasePaddleSpeed;
    [SerializeField] bool increaseRandomForce;

    [Header("Power-Up Type")]
    [SerializeField] bool decreaseGameSpeed;
    [SerializeField] bool increasePaddleSize;
    [SerializeField] bool increasePaddleSpeed;    

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
            DefineAndApply();
        }

    }

    private void DefineAndApply()
    {
        // Power-Downs
        if (increaseGameSpeed)
        {
            PowerDownGameSpeed();
        }
        else if (decreasePaddleSize)
        {
            PowerDownPaddleSize();
        }
        else if (decreasePaddleSpeed)
        {
            PowerDownPaddleSpeed();
        }
        else if (increaseRandomForce)
        {
            IncreaseRandomForce();
        }
        // Power-Ups
        if (decreaseGameSpeed)
        {
            PowerUpGameSpeed();
        }
        else if (increasePaddleSize)
        {
            PowerUpPaddleSize();
        }
        else if (increasePaddleSpeed)
        {
            PowerUpPaddleSpeed();
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
        thePaddle.ChangePaddleSize(-sizeModifier);
        Destroy(gameObject);
    }

    // Power-Ups:
    private void PowerUpPaddleSize()
    {
        thePaddle.ChangePaddleSize(sizeModifier);
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
