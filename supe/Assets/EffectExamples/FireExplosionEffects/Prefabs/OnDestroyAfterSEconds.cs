using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyAfterSEconds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var x = gameObject.GetComponent<ParticleSystem>();
        
        float duration = x.main.duration;
        Destroy(this.gameObject, duration);
    }

    
}
