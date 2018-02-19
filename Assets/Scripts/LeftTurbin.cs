using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurbin : MonoBehaviour {

    [SerializeField]
    float rcsThrust = 250f; // rcs = reaction control system
    [SerializeField]
    float mainThrust = 100f;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Thrust();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.A))
        {
            float tempThrust = mainThrust * Time.deltaTime;
            rb.AddRelativeForce(Vector3.up * mainThrust);
        }

    }

}
