using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadPlatform : MonoBehaviour
{
    public Animator animator;
    public bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpPadAction(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
        Vector2 thrustPower = new Vector2(0, .0003f);
        rb.AddForce(thrustPower, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Collides");
    }

}
