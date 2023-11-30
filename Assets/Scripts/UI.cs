using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Canvas canvas;

    private void Awake()
    {
        Ressources.PointChanged.AddListener(Test);
        canvas.gameObject.SetActive(false);
    }

    public void Test()
    {
        if (Time.time < 1)
        {
            return;
        }
        StartCoroutine(t());

        IEnumerator t()
        {
            canvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.25f);
            canvas.gameObject.SetActive(false);
        }
    }
}
