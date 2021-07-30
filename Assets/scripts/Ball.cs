using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip blockCollision;
    [SerializeField] AudioClip wallCollision;
    [SerializeField] AudioClip paddleCollision;
    Vector2 paddleToBallDistance;
    bool hasStarted = false;
    AudioSource audioSource;
 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       paddleToBallDistance = transform.position - paddle.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            lockBall();
        }
        launchBall();

    }

    private void lockBall()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }
    private void launchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            if (collision.gameObject.tag == "block")
            {
                audioSource.PlayOneShot(blockCollision);
            }
            if (collision.gameObject.tag == "wall")
            {
                audioSource.PlayOneShot(wallCollision);
            }
            if (collision.gameObject.tag == "paddle")
            {
                audioSource.PlayOneShot(paddleCollision);
            }
        }
    }
}   
