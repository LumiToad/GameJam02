using UnityEngine;

public class box : MonoBehaviour
{
    public float freezeDuration;
    float timer = 0;

    private Rigidbody rb;

    public void Freeze()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        transform.parent = FindObjectOfType<Wagen>().gameObject.transform;
        timer = freezeDuration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Unfreeze();
        }
    }

    public void Unfreeze()
    {
        rb.isKinematic = false;
        transform.SetParent(null);
    }
}
