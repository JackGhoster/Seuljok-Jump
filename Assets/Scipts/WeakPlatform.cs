using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public AudioSource SFX;
    private float transparency;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        transparency = spriteRenderer.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationChecker(animator, "active");
    }

    public void WeakPlatformAction(Rigidbody2D rb)
    {       
        Vector2 thrustPower = new Vector2(0, .002f);
        rb.AddForce(thrustPower);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator.SetTrigger("Collides");
        SFX.Play();

    }
    private void AnimationChecker(Animator an, string name)
    {
        if (an.GetCurrentAnimatorStateInfo(0).IsName(name))
        {
            transparency = spriteRenderer.color.a;
            OnTransparentDelete(transparency);
        }
    }
    private void OnTransparentDelete(float tp)
    {

        if (tp == 0)
        {
            Destroy(gameObject);
        }
    }


}
