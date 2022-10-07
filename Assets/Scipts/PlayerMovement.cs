using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask basicPlatform;
    private float horizontalMovement = 0f;
    public float movementSpeed = 1f;
    public float outOfBoundsRight = 0.6f;
    public float outOfBoundsLeft = -0.6f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement += Input.GetAxisRaw("Horizontal") * movementSpeed; 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
        onPlayerOutOfBounds();
    }

    private void onPlatformCollide()
    {

    }
    private void onPlayerOutOfBounds()
    {
        if (transform.position.x > outOfBoundsRight)
        {
            transform.position = new Vector2(outOfBoundsLeft, transform.position.y);
        }
        else if(transform.position.x < outOfBoundsLeft){
            transform.position = new Vector2(outOfBoundsRight, transform.position.y);
        }
    }
}
