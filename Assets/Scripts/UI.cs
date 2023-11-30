using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject canvas;

    float time = 60 * 3;
    int score_t = 0;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;

    public GameObject Over;

    private void Awake()
    {
        Ressources.PointChanged.AddListener(Test);
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timer.text = $"Timer {Math.Round(time, 2)}";
        score.text = $"Score {score_t}";

        Over.gameObject.SetActive(time <= 0);
    }

    public void Test()
    {
        if (Time.time < 1)
        {
            return;
        }

        score_t += 1;
        StartCoroutine(t());

        IEnumerator t()
        {
            canvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.25f);
            canvas.gameObject.SetActive(false);
        }
    }

    public void Looser()
    {
        SceneManager.LoadScene(0);
    }
}
