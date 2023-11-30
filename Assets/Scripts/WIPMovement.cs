using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIPMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;

    float time;
    float cooldown = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= cooldown)
        {
            time = 0;
            AddForce();
        }
    }

    public void AddForce()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
    }
}
