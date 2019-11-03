using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle myPaddle;

    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallDistance;

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) // hasStarted == false
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //generate random number
        int randomNumber = Random.Range(0, ballSounds.Length);

        //read clip from array position = randomNumber
        AudioClip myClip = ballSounds[randomNumber];

        GetComponent<AudioSource>().PlayOneShot(myClip);
    }

    private void LaunchBallOnClick()
    {
        //if left click is pressed
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //shoot the ball
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = myPaddle.transform.position;

        //set the Ball position to the paddlePosition + distance
        this.transform.position = paddlePosition + paddleToBallDistance;
    }
}
