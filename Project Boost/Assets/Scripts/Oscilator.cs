using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;   
    [SerializeField] float period = 2f;    


    void Start()
    {
        startingPosition = transform.position;

    }

    
    void Update()
    {
        if(period <= Mathf.Epsilon) {return;}   // for comparing float values to cero we use epsilon (smallest float representation) instead of something == 0
        float cycles = Time.time / period;    // continually growing over time (period in seconds)

        const float tau = Mathf.PI * 2;   // constant value of 6.283 = 2pi = tau = how many radius needed to reach a circumference's length
        float rawSinWave = Mathf.Sin(cycles * tau);    // going from -1 to 1 in the period that we specified (sin wave amplitude)

  //      Debug.Log(rawSinWave);    return values between -1 and 1 (sin wave amplitude)

        movementFactor = (rawSinWave + 1f)  / 2f;   // recalculated to go from from 0 to 1 so it's cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
