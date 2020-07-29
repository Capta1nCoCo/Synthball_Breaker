using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float controlSpeed = 15f;
    [SerializeField] float xRange = 6;
    
    float xThrow;

    GameSession theGameSession;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        PaddleControl();
    }    

    private void PaddleControl()
    {
        float clampedXPos;
        if (theGameSession.IsAutoplayEnabled())
        {
            clampedXPos = Mathf.Clamp(GetXPos(), -xRange, xRange);
        }
        else
        {
            xThrow = Input.GetAxis("Horizontal");
            float xOffset = xThrow * controlSpeed * Time.deltaTime;
            float rawXPos = transform.position.x + xOffset;
            clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        }
        Vector2 paddlePos = new Vector2(clampedXPos, transform.position.y);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {       
        return theBall.transform.position.x;        
    }
    
    public void ChangePaddleSize(float amount)
    {
        Vector3 paddleScale = new Vector3(transform.localScale.x + amount, transform.localScale.y);
        transform.localScale = paddleScale;
    }

    public void DecreasePaddleSpeed()
    {
        controlSpeed /= 2;
    }

    public void IncreasePaddleSpeed()
    {
        controlSpeed *= 2;
    }
}
