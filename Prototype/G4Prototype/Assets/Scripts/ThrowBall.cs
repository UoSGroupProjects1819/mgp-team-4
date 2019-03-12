using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ballObject;
    private SphereCollider ballCollider;
    [SerializeField]
    private float force;

    private Vector3 initialPos;
    private Quaternion initialRot;

    //public Quaternion rot;

    private bool hasBall;

    private shaderHandler shaderHandleScript;

    public GameObject player;

    private bool isCoroutineExecuting = false;

    void Start () {
        initialPos = ballObject.transform.localPosition;
        initialRot = ballObject.transform.localRotation;
        ballCollider = ballObject.GetComponent<SphereCollider>();

        shaderHandleScript = ballObject.GetComponent<shaderHandler>();
    }
	
	void OnMouseDown () {
	}

    void Update()
    {
        if(gameObject.transform.childCount != 0)
        {
            hasBall = true;
            ballCollider.enabled = false;
        }
        else
        {
            hasBall = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            print(initialPos);
        }

        if (GameHandler.Instance.gameState == GameHandler.gameStates.navigating)
        {
            if (Input.GetMouseButtonDown(0) && hasBall)
            {
                throwBall();
            }

            if (Input.GetMouseButtonDown(1))
            {
                resetBall(ballObject);
            }
        }       

        Debug.DrawRay(ballObject.transform.position, ballObject.transform.forward * force, Color.red);
    }

    public void throwBall()
    {        
        ballObject.transform.parent = null;
        Rigidbody ballRB = ballObject.GetComponent<Rigidbody>();
        ballRB.useGravity = true;
        ballRB.AddForce(ballObject.transform.forward * force, ForceMode.Impulse);
        Invoke("DelayCollide", 0.1f);
    }

    public void resetBall(GameObject ball)
    {
        ball.transform.parent = this.gameObject.transform;
        ball.transform.localPosition = initialPos;
        ball.transform.localRotation = initialRot;
        Rigidbody ballRB2 = ball.GetComponent<Rigidbody>();
        ballRB2.useGravity = false;
        ballRB2.velocity = Vector3.zero;
        ballRB2.angularVelocity = Vector3.zero;

        shaderHandleScript.canRipple = true;
        shaderHandleScript.count = 0;
    }

    void DelayCollide()
    {
        ballCollider.enabled = true;
    }
}
