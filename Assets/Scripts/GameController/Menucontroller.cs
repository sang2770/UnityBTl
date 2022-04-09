using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontroller : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Playgame()
    {
        audioSource.Stop();
        SceneManager.LoadScene("Scenes 1");
        
    }
    public void HowToPlay()
    {
        audioSource.Stop();

        SceneManager.LoadScene("How to play");
    }
}
