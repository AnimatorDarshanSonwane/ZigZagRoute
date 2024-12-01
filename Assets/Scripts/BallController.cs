using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Particle effect to instantiate when the ball collides with a diamond
    [SerializeField] private GameObject partical;

    // Speed at which the ball moves
    [SerializeField] private float speed;

    // Flags to track the state of the game and ball movement
    bool started;
    bool gameOver;

    // Rigidbody component for controlling the ball's physics
    Rigidbody rb;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Get the Rigidbody component attached to the ball
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game state flags
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game has not started yet
        if (!started)
        {
            // Start the game when the player clicks the mouse
            if (Input.GetMouseButtonDown(0))
            {
                // Set the ball's initial velocity to move along the x-axis
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                // Notify the GameManager to start the game
                GameManager.Instance.StartGame();
            }
        }

        // Check if the ball is not above any surface (falling)
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;

            // Set the ball's velocity to fall quickly downwards
            rb.velocity = new Vector3(0, -25f, 0);

            // Notify the CameraFollow script that the game is over
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            // Notify the GameManager that the game is over
            GameManager.Instance.GameOver();
        }

        // Switch the ball's direction when the player clicks the mouse, if the game is not over
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    // Method to switch the ball's movement direction between x and z axes
    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            // If the ball is moving along the z-axis, switch to moving along the x-axis
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            // If the ball is moving along the x-axis, switch to moving along the z-axis
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    // Trigger event when the ball collides with a diamond
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            // Instantiate a particle effect at the diamond's position
            GameObject part = Instantiate(partical, other.gameObject.transform.position, Quaternion.identity);

            // Destroy the diamond object
            Destroy(other.gameObject);

            // Destroy the particle effect after 1 second
            Destroy(part, 1f);
        }
    }
}
