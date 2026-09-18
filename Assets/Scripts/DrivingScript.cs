using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelScript[] wheels; // tu bêda wszystkie ko³a
    public float torque = 200; // moment obrotowy
    public float maxSteerAngle = 30; // maksymalny k¹t wychylenia 
    public float maxBrakeTorque = 500; // moment hamowania
    public float maxSpeed = 300; // maksymalna prêdkoœæ
    public Rigidbody rb;
    public float currentSpeed; // aktualna prêdkoœæ

    public void Drive(float accel, float brake, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        float thrustTorque = 0;
        if(currentSpeed < maxSpeed)
        {
            thrustTorque = accel * torque;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
