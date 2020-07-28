using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float yPush = 15f;
    [SerializeField] float xPush = 2f;
    [SerializeField] AudioClip[] hitSonds;
    [SerializeField] float randomForce = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // references
    AudioSource audioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {        
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {       
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomForce), 
            Random.Range(0f, randomForce));

        if (hasStarted)
        {
            AudioClip clip = hitSonds[Random.Range(0, hitSonds.Length)];
            audioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }        
    }

}
