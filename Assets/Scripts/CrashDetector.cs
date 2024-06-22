using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayReloadScene = 1f;
    [SerializeField] ParticleSystem finishEffect;

    [SerializeField] AudioClip crashSFX;
    bool triggered = false;



    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !triggered) {
            triggered=true;
             FindObjectOfType<PLayerController>().disableControls();
             finishEffect.Play();
             GetComponent<AudioSource>().PlayOneShot(crashSFX);
             Invoke("ReloadScene",delayReloadScene);
        }
        if(other.tag == "Ground") {
             finishEffect.Play();
        }
    }
    

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
