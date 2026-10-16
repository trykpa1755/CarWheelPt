using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScript driveScript;

    float lastTimeMoving = 0;
    CheckPointController checkPointController;

    // Start is called before the first frame update
    void Start()
    {
        driveScript = GetComponent<DrivingScript>();
        checkPointController = driveScript.rb.GetComponent<CheckPointController>();
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if (!RaceController.racing) accel = 0;
        driveScript.Drive(accel, brake, steer);
    }
}
