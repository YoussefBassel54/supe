using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudioPlayer : MonoBehaviour
{
    public static ExplosionAudioPlayer instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public AudioSource explosionSound;

    public void PlayExplosionSound()
    {
        Debug.Log("sound play");
        explosionSound.Play();
    }
    
}
