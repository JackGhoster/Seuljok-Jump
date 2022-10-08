using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public Transform background1;
    public Transform background2;
    private float bgSize;

    public Transform target;
    public float MIN_X = -0.6f;
    public float MAX_X = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        bgSize = background1.GetComponent<SpriteRenderer>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = new Vector2(target.position.x, target.position.y);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), targetPos.y, transform.position.z);
        bgHandler();
        //StartCoroutine(CameraDelay(targetPos, 1f));
    }

    //IEnumerator CameraDelay(Vector2 targetPos, float duration)
    //{
    //    float time = 0;
    //    while(time < duration)
    //    {
    //        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MIN_X, MAX_X), targetPos.y, transform.position.z);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //}

    private void bgHandler()
    {
        if (transform.position.y >= background2.position.y)
        {
            background1.position = new Vector3(background1.position.x, background2.position.y + bgSize, background1.position.z);
            bgSwitch();
        }

    }
    private void bgSwitch()
    {
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }
}
