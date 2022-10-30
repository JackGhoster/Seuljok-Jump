using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI pointCounter;
    public int newPoints;
    public Transform target;
    private float targetOldPosY;
    // Start is called before the first frame update
    void Start()
    {
        targetOldPosY = target.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnTargetMovePointsChanged();
        pointCounter.text = Convert.ToString(newPoints);
    }

    public void OnTargetMovePointsChanged()
    {
        if (target.position.y > targetOldPosY)
        {
            newPoints += 1;
            targetOldPosY = target.transform.position.y;
            
        }
    }
}
