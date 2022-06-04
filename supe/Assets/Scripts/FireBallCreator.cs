using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreator : MonoBehaviour
{
    public GameObject ball;
    public GameObject rightOffset;
    public GameObject leftOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateBall(ball);
    }

    void CreateBall(GameObject ball)
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.1)
        {
            Instantiate(ball, leftOffset.transform.position, leftOffset.transform.rotation);
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.1)
        {
            Instantiate(ball, rightOffset.transform.position, rightOffset.transform.rotation);
        }

    }

    
}
