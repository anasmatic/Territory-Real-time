using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float steer;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;


    /*private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
    }*/
    private void Update()
    {
        transform.Translate(0,0,1*Time.deltaTime * speed);
        
        if (variableJoystick.IsSteering == false) return;
        
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(variableJoystick.Horizontal * speed, 0, variableJoystick.Vertical * speed));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, steer * Time.deltaTime);

    }
}