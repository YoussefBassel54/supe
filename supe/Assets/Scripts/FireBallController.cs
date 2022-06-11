using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public GameObject explosion;
    public float dieTime = 5f;
    public float blastRadius = 5f;
    public float explosionForce = 10;
    
    void OnCollisionEnter(Collision collision)
    {
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
 


    IEnumerator StartExplosion(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        GameObject explosionParticle = Instantiate(explosion, position, rotation);

        var x=explosionParticle.GetComponent<ParticleSystem>();
        x.Play();


        

        float duration = x.main.duration;
        yield return new WaitForSeconds(duration);

        explosionParticle.GetComponent<ParticleSystem>().Stop();
        Destroy(explosionParticle);
       
    }
}
