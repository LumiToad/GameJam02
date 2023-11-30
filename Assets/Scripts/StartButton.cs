using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene(1);
    }
}
