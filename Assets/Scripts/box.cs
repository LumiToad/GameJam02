using UnityEngine;

public class box : MonoBehaviour
{
    public float freezeDuration;
    float timer = 0;

    public void Freeze()
    {
        GetComponent<Rigidbody>().isKinematic = true;
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
        GetComponent<Rigidbody>().isKinematic = false;
        transform.SetParent(null);
    }
}
