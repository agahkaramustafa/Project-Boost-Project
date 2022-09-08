using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;

            case "Finish":
                Debug.Log("End of the game");
                break;

            case "Fuel":
                Debug.Log("Fueled up!");
                break;

            default:
                Debug.Log("Boom!");
                break;
        }
    }
}
