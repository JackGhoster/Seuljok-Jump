using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButtonHandler : MonoBehaviour
{

    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;
    

    protected delegate void ButtonMethod();
    public float buttonOutput;
    private void FixedUpdate()
    {
        ButtonMethodsInvoker(OnLeftButtonDown, leftButtonPressed);
        ButtonMethodsInvoker(OnRightButtonDown, rightButtonPressed);        
    }

    protected void ButtonMethodsInvoker(ButtonMethod method, bool pressState)
    {
        if (pressState == true)
        {
            method();
        }
    }




    public void OnLeftButtonDown()
    {

        buttonOutput = -1f;  
        leftButtonPressed = true;
    }

    public void OnLeftButtonUp()
    {
        buttonOutput = 0f;
        leftButtonPressed = false;
    }


    public void OnRightButtonDown()
    {
        buttonOutput = 1f;     
        rightButtonPressed = true;
    }

    public void OnRightButtonUp()
    {
        buttonOutput = 0f;
        rightButtonPressed = false;
    }

}
