using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the ball GameObject that the camera will follow
    public GameObject ball;

    // Offset between the ball and the camera's initial position
    Vector3 offset;

    // Lerp rate controls the smoothness of the camera movement
    public float lerpRate;

    // Flag to check if the game is over
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial offset between the camera and the ball
        offset = ball.transform.position - transform.position;

        // Initialize gameOver to false, allowing the camera to follow the ball
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        // If the game is not over, continue following the ball
        if (!gameOver)
        {
            FollowCamera();
        }
    }

    // Method to smoothly follow the ball
    void FollowCamera()
    {
        // Get the current position of the camera
        Vector3 pos = transform.position;

        // Calculate the target position by applying the offset to the ball's position
        Vector3 targetPosition = ball.transform.position - offset;

        // Smoothly interpolate the camera's position towards the target position using Lerp
        pos = Vector3.Lerp(pos, targetPosition, lerpRate * Time.deltaTime);

        // Update the camera's position
        transform.position = pos;
    }
}
