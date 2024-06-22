using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem skyEffect;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
            skyEffect.Play();

    }
    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
            skyEffect.Stop();
    }
}
