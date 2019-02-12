using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ballPrefab;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float force;



    void Start () {
		
	}
	
	void OnMouseDown () {
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(ballPrefab, transform.position + transform.forward * offset, transform.rotation);
            Rigidbody bRb = b.GetComponent<Rigidbody>();
            bRb.AddForce(b.transform.position + b.transform.forward * force, ForceMode.Impulse);
        }
        
    }
}
