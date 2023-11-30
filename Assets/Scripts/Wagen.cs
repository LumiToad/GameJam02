using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagen : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 2;
    }

    private void Update()
    {
        ResetAngular();
    }

    private void ResetAngular()
    {
        rb.angularVelocity = Vector3.MoveTowards(rb.angularVelocity, Vector3.zero, 0.01f);
    }
}
