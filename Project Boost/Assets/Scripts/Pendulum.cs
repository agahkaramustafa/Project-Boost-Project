using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float turnSpeed = 1;
    [SerializeField] float period = 2f;

    float movementFactor;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f); // recalculated to go from 0 to 2

        transform.Rotate(1 * turnSpeed * movementFactor, 0, 0);
    }


}
