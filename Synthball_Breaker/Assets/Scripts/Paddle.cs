using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float controlSpeed = 15f;
    [SerializeField] float xRange = 6;
    
    float xThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PaddleControl();
    }    

    private void PaddleControl()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.position.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        Vector2 paddlePos = new Vector2(clampedXPos, transform.position.y);        
        transform.position = paddlePos;
    }

}
