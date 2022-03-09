using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Rigidbody rigidbody;
    AudioSource audioSource;
    
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
            //audioSource.Stop();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } else
        {
            audioSource.Stop();
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

    void ApplyRotation(float rotationThisFrame)
    {
        rigidbody.freezeRotation = true; //freeze rotation..
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rigidbody.freezeRotation = false; //unfreeze rotation
    }
}
