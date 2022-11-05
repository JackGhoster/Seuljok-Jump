using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    //public TouchButtonHandler touchHandler;
    public GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    protected float movementSpeed = 2f;
    private float horizontalMovement = 0f;
    private float buttonSpeed;
    private float maxSpeed = 100f;
    private float limitedXSpeed = 95f;
    private float maxSpeedY = 1.65f;
    private float outOfBoundsRight = 0.6f;
    private float outOfBoundsLeft = -0.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        buttonSpeed = gameManager.buttonXSpeed;
        SpeedLimiter();
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, (rb.velocity.y < maxSpeedY) ? rb.velocity.y : maxSpeedY);
        OnPlayerOutOfBounds();
    }


    private void OnPlayerOutOfBounds()
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

    private void SpeedLimiter()
    {
        //PC Code
        //if (horizontalMovement < maxSpeed && horizontalMovement > -maxSpeed)
        //{
        //    horizontalMovement += (Input.GetAxisRaw("Horizontal") * movementSpeed);
        //}
        //else
        //{
        //    horizontalMovement = (Input.GetAxisRaw("Horizontal") * limitedXSpeed);
        //}
        
        //Touch Code
        if (horizontalMovement < maxSpeed && horizontalMovement > -maxSpeed)
        {
            horizontalMovement += (buttonSpeed  * movementSpeed);
        }
        else
        {
            horizontalMovement = (buttonSpeed * limitedXSpeed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Collides");
        //Platform platform = gameObject.AddComponent(typeof(Platform)) as Platform;
        Platform platform = gameObject.AddComponent<Platform>();
        

        GameObject temp = collision.gameObject;

        platform.PlatformHandler(temp, rb);
        Destroy(platform);
    }
}