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
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            GameObject currentFireBall = Instantiate(ball, leftOffset.transform.position, leftOffset.transform.rotation);
            currentFireBall.GetComponent<Rigidbody>().AddForce(leftOffset.transform.forward * 8, ForceMode.Impulse);
            return;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two)||Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentFireBall = Instantiate(ball, rightOffset.transform.position, rightOffset.transform.rotation);
            currentFireBall.GetComponent<Rigidbody>().AddForce(rightOffset.transform.forward * 8, ForceMode.Impulse);
        }

        
    }

    


}
