using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menucontroller : MonoBehaviour
{
    AudioSource audioSource;
    public InputField txtname;
  
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Playgame()
    {
        audioSource.Stop();
        GameManager.Instance.setNamePlayer(txtname.text);
        SceneManager.LoadScene("Scenes 1");
        
    }
    public void HowToPlay()
    {
        audioSource.Stop();
        GameManager.Instance.setNamePlayer(txtname.text);
        SceneManager.LoadScene("How to play");
    }
}
