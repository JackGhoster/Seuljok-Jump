using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public Vector2 targetPos;
    public Transform background1;
    public Transform background2;
    private float bgSize;

    public Transform target;
    public float MIN_X = -0.6f;
    public float MAX_X = 0.6f;
    //private float targetAccel;

    // Start is called before the first frame update
    void Start()
    {
        bgSize = background1.GetComponent<SpriteRenderer>().size.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPos = new(target.position.x, target.position.y);
        //targetAccel = targetPos.y * Time.fixedDeltaTime > 0 ? (targetPos.y * (Time.fixedDeltaTime * Time.fixedDeltaTime)) : targetAccel;
        BgHandler();
        CameraHeightLimiter();  
    }

    private void BgHandler()
    {
        if (transform.position.y >= background2.position.y)
        {
            background1.position = new Vector3(background1.position.x, background2.position.y + bgSize, background1.position.z);
            BgSwitch();
        }

    }
    private void BgSwitch()
    {
        (background2, background1) = (background1, background2);
    }
    private void MoveToTarget()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), targetPos.y, transform.position.z);     
    }


    public void CameraHeightLimiter()
    {

        if (targetPos.y >= background1.position.y)
        {

            MoveToTarget();

        }
        else if(targetPos.y < background1.position.y - bgSize/2)
        {
            Debug.Log("Hi");
        }
    }
}
