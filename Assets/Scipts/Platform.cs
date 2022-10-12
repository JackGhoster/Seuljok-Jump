using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private string basicPlatform = "basicPlatform";
    private string jumpPad = "jumpPad";
    private string spikePlatform = "spikePlatform";
    private string weakPlatform = "weakPlatform";

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlatformHandler(GameObject platform, Rigidbody2D playerRb)
    {
        if (platform.CompareTag(basicPlatform))
        {
            BasicPlatformAction(playerRb);
        }
        else if (platform.CompareTag(jumpPad))
        {
            //JumpPadPlatform jp = gameObject.AddComponent<JumpPadPlatform>();
            JumpPadPlatform jp = new JumpPadPlatform();

            jp.JumpPadAction(playerRb);
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
}

