using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayReloadScene = 1f;

    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip crashSFX;



    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",delayReloadScene);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
