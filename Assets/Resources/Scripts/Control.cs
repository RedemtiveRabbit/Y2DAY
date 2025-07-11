using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed = 2;
    // Update is called once per frame
    void FixedUpdate()
    {
        var body = GetComponent<Rigidbody2D>();
        var slide = Input.GetAxis("Horizontal");
        var lift = Input.GetAxis("Vertical");
        var forward = body.linearVelocity;
        forward.x = slide * speed;
        forward.y = lift * speed;
        body.linearVelocity = forward;
    }
}
