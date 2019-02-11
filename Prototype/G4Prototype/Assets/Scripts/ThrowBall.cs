using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ballPrefab;
    [SerializeField]
    private float offset;


	void Start () {
		
	}
	
	void OnMouseDown () {
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnVector = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.forward.z + offset);
            Instantiate(ballPrefab, spawnVector, Quaternion.identity);
        }
        
    }
}
