using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] bool isfinished = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isfinished)
        {
            isfinished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
