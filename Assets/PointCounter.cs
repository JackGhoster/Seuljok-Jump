using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Audio;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI pointCounter;
    public int newPoints;
    public Transform target;
    public AudioSource audioSource;
    private float targetOldPosY;

    private float pointsToPitch = 1000;
    private float pitchMargin = 0.06f;
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
            OnPointsReachedPitchUp();

        }
    }
    public void OnPointsReachedPitchUp()
    {
        if(newPoints == pointsToPitch)
        {
            audioSource.pitch += pitchMargin;
            pointsToPitch *= 2f;
        }
    }
}
