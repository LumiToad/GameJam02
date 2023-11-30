using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagen : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1;
    }

    private void FixedUpdate()
    {
        ResetAngular();
    }

    private void ResetAngular()
    {
        Vector3 newAngularVelocity = rb.velocity;

        newAngularVelocity.z = 0;

        rb.angularVelocity = Vector3.MoveTowards(newAngularVelocity, Vector3.zero, 1.0f);
    }
}
