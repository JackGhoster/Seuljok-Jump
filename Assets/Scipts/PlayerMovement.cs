using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask basicPlatform;
    public float basicPlatformJumpForce = 0.5f;
    public float movementSpeed = 0.2f;
    private float horizontalMovement = 0f;
    private float maxSpeed = 100f;
    private float limitedSpeed = 95f;
    private float outOfBoundsRight = 0.6f;
    private float outOfBoundsLeft = -0.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speedLimiter();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
        onPlayerOutOfBounds();
  
    }


    private void onPlayerOutOfBounds()
    {
        if (transform.position.x > outOfBoundsRight)
        {
            transform.position = new Vector2(outOfBoundsLeft, transform.position.y);
        }
        else if (transform.position.x < outOfBoundsLeft)
        {
            transform.position = new Vector2(outOfBoundsRight, transform.position.y);
        }
    }

    private void speedLimiter()
    {
        //if (rb.velocity.x < maxSpeed && rb.velocity.x > -maxSpeed)
        if (horizontalMovement < maxSpeed && horizontalMovement > -maxSpeed)
        {
            horizontalMovement += (Input.GetAxisRaw("Horizontal") * movementSpeed);
        }
        else
        {
            horizontalMovement = (Input.GetAxisRaw("Horizontal") * limitedSpeed);
        }

    }
}
