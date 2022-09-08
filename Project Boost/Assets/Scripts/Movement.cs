using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float thrustForce;
    [SerializeField] int rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustForce);
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {

            ApplyRotation(rotationSpeed);

        }


        else if (Input.GetKey(KeyCode.D))
        {

            ApplyRotation(-rotationSpeed);

        }
    }

    private void ApplyRotation(int rotationThisFrame)
    {
        playerRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        playerRb.freezeRotation = false;
    }
}
