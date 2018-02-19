using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [SerializeField]
    float rcsThrust = 250f; // rcs = reaction control system
    [SerializeField]
    float mainThrust = 100f;

    Rigidbody rb;
    AudioSource audioSource;

	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}

	void Update () {
        Thrust();
        Rotate();
	}

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float tempThrust = mainThrust * Time.deltaTime;
            rb.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rb.freezeRotation = true; //take manual control of rotation

        float tempRotation = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * tempRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * tempRotation);
        }

        rb.freezeRotation = false; //resume ohysics control of rotation
    }

    
}
