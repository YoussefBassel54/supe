using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreator : MonoBehaviour
{
    public GameObject ball;
    public GameObject rightOffset; //empty GameObject placed as a child to the right hand prefab to get its location and rotaion
    public GameObject leftOffset; //empty GameObject placed as a child to the left hand prefab to get its location and rotaion

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
        //launch fireball from left hand when Y on the left controller is pressed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            GameObject currentFireBall = Instantiate(ball, leftOffset.transform.position, leftOffset.transform.rotation);
            currentFireBall.GetComponent<Rigidbody>().AddForce(leftOffset.transform.forward * 8, ForceMode.Impulse);
            return;
        }

        //launch fireball from right hand when B on the right controller is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two)||Input.GetKeyDown(KeyCode.Space)) //the space control is for testing directly in the editor without building
        {
            GameObject currentFireBall = Instantiate(ball, rightOffset.transform.position, rightOffset.transform.rotation);
            currentFireBall.GetComponent<Rigidbody>().AddForce(rightOffset.transform.forward * 8, ForceMode.Impulse);            
            return;
        }

        
    }

    


}
