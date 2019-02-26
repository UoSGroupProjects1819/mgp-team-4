using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHandler : MonoBehaviour
{
    public GameObject ballObject;
    public float checkRadius = 1.5f;

    public string[] potentialItems = new string[3];
    private string actualItem;

    public Material test;
    private MeshRenderer objectMat;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Ball");
        objectMat = gameObject.GetComponent<MeshRenderer>();
        actualItem = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(ballObject.transform.position, gameObject.transform.position) < checkRadius)
        {
            objectMat.material = test;
        }   
    }
}
