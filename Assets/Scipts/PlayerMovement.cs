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
        
        //animator.SetFloat("Speed Y", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, (rb.velocity.y < maxSpeedY) ? rb.velocity.y : maxSpeedY);
        onPlayerOutOfBounds();
        //Debug.Log(rb.velocity.y);
        
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
            horizontalMovement = (Input.GetAxisRaw("Horizontal") * limitedXSpeed);
        }

        //if(rb.velocity.y > maxSpeedY){
        //    rb.velocity.y = 2f;
        //}

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Collides");
        Platform platform = new Platform();
        //StartCoroutine(AnimTriggerDelay("Collides",5));
        GameObject temp = collision.gameObject;
        platform.PlatformHandler(temp, rb);
    }

    //IEnumerator AnimTriggerDelay(string name, float duration)
    //{
    //    animator.SetTrigger(name);
    //    float time = 0;
    //    while (time < duration)
    //    {
    //        time += Time.deltaTime;       
    //        animator.ResetTrigger(name);
    //        yield return null;

    //    }

    //}
}

public class Platform
{
    private string basicPlatform = "basicPlatform";
    private string jumpPad = "jumpPad";
    private string spikePlatform = "spikePlatform";
    private string weakPlatform = "weakPlatform";

    public void PlatformHandler(GameObject platform, Rigidbody2D playerRb)
    {
        if (platform.CompareTag(basicPlatform))
        {
            BasicPlatformAction(playerRb);
        }
        else if (platform.CompareTag(jumpPad))
        {
            JumpPadAction(playerRb);
        }
        else if (platform.CompareTag(spikePlatform))
        {

        }
        else if (platform.CompareTag(weakPlatform))
        {

        }
    }
    private void BasicPlatformAction(Rigidbody2D rb)
    {
        Vector2 thrustPower = new Vector2(0, .004f);
        rb.AddForce(thrustPower);
    }

    private void JumpPadAction(Rigidbody2D rb)
    {
        Vector2 thrustPower = new Vector2(0, .007f);
        rb.AddForce(thrustPower);
    }

}
