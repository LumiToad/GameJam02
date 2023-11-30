using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    private static Ressources instance;
   
    public static Ressources Instance
    {
        get
        {
            if(instance == null)
            {
                var ob = new GameObject();
                instance = ob.AddComponent<Ressources>();
            }
            return instance;
        }
    }

    public static List<ExitPoints> points = new List<ExitPoints>();

    public static void EnableRandomPoint(ExitPoints exception)
    {
        if(points.Count <= 2)
        {
            return;
        }

        foreach(var point in points)
        {
            point.gameObject.SetActive(false);
        }

        while (true)
        {
            var randomPoint = points[Random.Range(0, points.Count)];
            if(randomPoint != exception)
            {
                randomPoint.gameObject.SetActive(true);
                return;
            }
        }
    }
}
