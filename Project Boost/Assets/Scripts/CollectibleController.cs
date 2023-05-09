using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] float freq;
    [SerializeField] float amp;
    [SerializeField] AudioClip collectSound;

    Vector3 initPos;
    CollisionHandler collisionHandler;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);

        if (other.gameObject.CompareTag("Player") && !collisionHandler.GetIsTransitioning)
        {
            FindObjectOfType<ScoreTextHandler>().ModifyScoreText();
            Destroy(gameObject);
        }
    }

}
