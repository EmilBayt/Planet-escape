using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                Debug.Log("You hit obstacle");
                break;
            case "Fuel":
                Debug.Log("You got fuel");
                break;
            default:
                Debug.Log("You are launching");
                break;
        }
    }
}
