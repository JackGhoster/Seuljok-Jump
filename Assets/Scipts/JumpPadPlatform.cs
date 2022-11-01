using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPadPlatform : MonoBehaviour
{
    public Animator animator;
    public AudioSource SFX;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!System.Object.ReferenceEquals(gameObject,null))
        {
            animator.SetTrigger("Collides");
            SFX.Play();         
        }
    }   

    public void JumpPadAction(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
        Vector2 thrustPower = new Vector2(0, .0004f);
        rb.AddForce(thrustPower, ForceMode2D.Impulse);
    }


}
