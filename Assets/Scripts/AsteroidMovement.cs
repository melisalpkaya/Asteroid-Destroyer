using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    // //This script controls the movement of asteroids and ensures they stay within the screen boundaries. 
    // It applies a random speed and direction to the asteroids using a Rigidbody component.
   
    public float speed = 5f;
    private Rigidbody rb;
    private Camera cam;

    private void Start()
    {
         cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, 0f) * speed; // Provides random motion in X and Y axis only
    }

    private void Update()
    {
        // Reset Z position on every update to keep Z position fixed
        Vector3 currentPosition = transform.position;
        currentPosition.z = 10f;
        transform.position = currentPosition;
        stayInScreen();
    }
    public void stayInScreen()
    {
        Vector3 newPos = transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x > 1)
        {
            newPos.x = -newPos.x + 0.2f;
        }
        else if (viewPos.x < 0)
        {
            newPos.x = -newPos.x - 0.2f;
        }

        if (viewPos.y > 1)
        {
            newPos.y = -newPos.y + 0.2f;
        }
        else if (viewPos.y < 0)
        {
            newPos.y = -newPos.y - 0.2f;
        }

        transform.position = newPos;

}



}
