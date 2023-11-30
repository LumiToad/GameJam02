using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Ressources : MonoBehaviour
{
    private static Ressources instance;
    public static UnityEvent PointChanged = new UnityEvent();
   
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
    public static int listIndex = 0;

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
            var randomPoint = points[listIndex];
            if(randomPoint != exception)
            {
                randomPoint.gameObject.SetActive(true);
                PointChanged?.Invoke();
                listIndex++;
                return;
            }
        }
    }
}
