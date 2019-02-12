using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ballObject;
    [SerializeField]
    private float force;

    private Vector3 initialPos;
    private Quaternion initialRot;



    void Start () {
        initialPos = ballObject.transform.localPosition;
        initialRot = ballObject.transform.localRotation;
    }
	
	void OnMouseDown () {
	}

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print(initialPos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ballObject.transform.parent = null;
            Rigidbody ballRB = ballObject.GetComponent<Rigidbody>();
            ballRB.useGravity = true;
            ballRB.AddForce(ballObject.transform.position + ballObject.transform.forward * force, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(1))
        {
            resetBall(ballObject);
        }

        Debug.DrawRay(ballObject.transform.position, ballObject.transform.forward * force, Color.red);
        
    }

    void resetBall(GameObject ball)
    {
        ball.transform.parent = this.gameObject.transform;
        ball.transform.localPosition = initialPos;
        ball.transform.localRotation = initialRot;
        Rigidbody ballRB2 = ball.GetComponent<Rigidbody>();
        ballRB2.useGravity = false;
        ballRB2.velocity = Vector3.zero;
        ballRB2.angularVelocity = Vector3.zero;
    }
}
