using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody playerRb;
    AudioSource audioSource;

    [SerializeField] float thrustForce;
    [SerializeField] int rotationSpeed;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            if (!audioSource.isPlaying)
            {
                //audioSource.time = 2.0f;
                audioSource.PlayOneShot(mainEngine);
            }

            if (!thrustParticle.isPlaying)
            {
                thrustParticle.Play();
            }
        }

        else
        {
            audioSource.Stop();
            thrustParticle.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!leftParticle.isPlaying)
            {
                leftParticle.Play();
            }
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (!rightParticle.isPlaying)
            {
                rightParticle.Play();
            }
            ApplyRotation(-rotationSpeed);
        }

        else
        {
            leftParticle.Stop();
            rightParticle.Stop();
        }

    }

    private void ApplyRotation(int rotationThisFrame)
    {
        playerRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        playerRb.freezeRotation = false;
    }
}
