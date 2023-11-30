using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoints : MonoBehaviour
{
    private void Awake()
    {
        Ressources.points.Add(this);
        gameObject.SetActive(false);

        Ressources.EnableRandomPoint(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Car>() != null)
        {
            Ressources.EnableRandomPoint(this);
        }
    }
}
