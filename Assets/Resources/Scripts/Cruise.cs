using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cruise : MonoBehaviour
{
    public float speed = 5.0f;

    void FixedUpdate()
    {
        var body = GetComponent<Rigidbody>();
        var forward = transform.InverseTransformDirection(body.linearVelocity);
        forward.z = speed;
        body.linearVelocity = transform.TransformDirection(forward);
    }
}
