using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShipControl : MonoBehaviour
{
    //this script handles ship movement, ensures it stays within the screen boundaries, and manages the selection of the ship based on player preferences.

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    private Camera cam;
    private Rigidbody rb;
    Vector3 direction;

public GameObject defaultShip;
public GameObject purchasedShip;

  
void Start()
{
    cam = Camera.main;
    rb = GetComponent<Rigidbody>();
    bool choose = PlayerPrefs.GetInt("ChooseValue", 0) == 1;
    Debug.Log(choose);

    if (choose)
    {
        // if choose is true, yellow ship is used
        defaultShip.SetActive(false);
        purchasedShip.SetActive(true);
    }
    else
    {
        // if choose is true, red ship is used
        defaultShip.SetActive(true);
        purchasedShip.SetActive(false);
    }
}

    // Update is called once per frame
    void Update()
    {
        moveIt();
        stayInScreen();
    }

    void FixedUpdate()
    {
        if (direction == Vector3.zero)
        {
            return;
        }
        rb.AddForce(direction * moveSpeed, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public void moveIt()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(touchPosition);

            direction = worldPosition - transform.position;
            direction.z = 0;
            direction.Normalize();


        }
        else
        {
            direction = Vector3.zero;
        }
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
