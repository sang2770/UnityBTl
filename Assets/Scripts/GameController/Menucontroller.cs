using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontroller : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("Scenes 1");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("How to play");
    }
}
