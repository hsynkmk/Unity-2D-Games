using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" || collision.tag == "Rock")
        {
            crashEffect.Play();
            Invoke("ReloadScene", 0.2f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}