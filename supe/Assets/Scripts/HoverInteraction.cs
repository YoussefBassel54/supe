using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInteraction : MonoBehaviour
{

    bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            transform.Rotate(Vector3.up * 20);
        }
    }

    public void HoverInteract(bool b)
    {
        rotating = b;
    }
}
