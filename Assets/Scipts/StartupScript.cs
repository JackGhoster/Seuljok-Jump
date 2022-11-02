using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.SceneManagement; 
public class StartupScript : MonoBehaviour
{
    public Animator animator;


    protected string sceneToLoad = "MenuScene";

    protected SpriteRenderer spriteRenderer;

    private float transparency;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transparency = spriteRenderer.color.a;
    }


    private void FixedUpdate()
    {
        transparency = spriteRenderer.color.a;
        CheckTransparency(transparency);
    }

    public void CheckTransparency(float tp)
    {
        if (tp == 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
