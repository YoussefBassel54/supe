using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{    
    public GameObject explosion;
    public GameObject explosionAudio;
    public float dieTime = 5f;
    public float blastRadius = 5f;
    public float explosionForce = 10;
    

    //logic for explosion physics of fire ball
    void OnCollisionEnter(Collision collision)
    {
        ExplosionAudioPlayer.instance.PlayExplosionSound();
        StartCoroutine(StartExplosion(collision));
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }
        
        Destroy(gameObject);
    }
 


    //timer logic to destroy created fire ball instance and particle system after collision
    IEnumerator StartExplosion(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        GameObject explosionParticle = Instantiate(explosion, position, rotation);

        var x = explosionParticle.GetComponent<ParticleSystem>();
        explosionAudio.GetComponent<ExplosionAudioPlayer>();
        x.Play();
        

        

        float duration = x.main.duration;
        yield return new WaitForSeconds(duration);

        explosionParticle.GetComponent<ParticleSystem>().Stop();
        Destroy(explosionParticle);
       
    }
}
