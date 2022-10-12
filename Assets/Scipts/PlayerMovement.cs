using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask basicPlatform;
    public float basicPlatformJumpForce = 0.5f;
    public float movementSpeed = 0.2f;
    private float horizontalMovement = 0f;
    private float maxSpeed = 100f;
    private float limitedXSpeed = 95f;
    private float maxSpeedY = 2f;
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
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, (rb.velocity.y < maxSpeedY) ? rb.velocity.y : maxSpeedY);
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
        if (horizontalMovement < maxSpeed && horizontalMovement > -maxSpeed)
        {
            horizontalMovement += (Input.GetAxisRaw("Horizontal") * movementSpeed);
        }
        else
        {
            horizontalMovement = (Input.GetAxisRaw("Horizontal") * limitedXSpeed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Collides");
        //Platform platform = gameObject.AddComponent(typeof(Platform)) as Platform;
        Platform platform = new Platform();

        GameObject temp = collision.gameObject;

        platform.PlatformHandler(temp, rb);
    }
}