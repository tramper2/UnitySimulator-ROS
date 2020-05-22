﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntakeControl : MonoBehaviour
{
    private int numBalls = 3;

    [Header("Ball Pickup")]
    public Text powerCellText;
    public int maxNumberBalls = 5;

    [Header("Intake Motor")]
    public int wantedVelocity = 150;

    // Intake Motor Control
    void Start()
    {
        retractIntake();
    }

    public void deployIntake()
    {
        var hinge = GetComponent<HingeJoint>();
        var motor = hinge.motor;
        motor.targetVelocity = wantedVelocity;

        hinge.motor = motor;
    }

    public void retractIntake()
    {
        var hinge = GetComponent<HingeJoint>();
        var motor = hinge.motor;
        motor.targetVelocity = -wantedVelocity;

        hinge.motor = motor;
    }

    // Ball Pickup
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PowerCell" && numBalls < maxNumberBalls)
        {
            numBalls++;
            Destroy(collision.collider.gameObject);
            updateText();
        }
    }

    public void subtractBall()
    {
        numBalls--;
        updateText();
    }

    void updateText()
    {
        powerCellText.text = "Power Cells: " + numBalls;
    }

    public int getNumberBalls()
    {
        return numBalls;
    }
}
