using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderHandler : MonoBehaviour
{

    public Material shaderMat;

    public float rippleSpeed;
    float[] radius = { 0,0,0 };

    int currentRipple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < radius.Length; i++)
        { 
            if (radius[i] <= 3.0f)
            {
                radius[i] += Time.deltaTime * rippleSpeed;

                shaderMat.SetFloat("_Radius" + (i + 1).ToString(), radius[i]);

            }
        }
        //shaderMat.SetVector("_Center", ballPos);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Vector3 ballPos = transform.position;

        switch (currentRipple)
        {
            case 0:
                shaderMat.SetVector("_Center1", ballPos);
                break;
            case 1:
                shaderMat.SetVector("_Center2", ballPos);
                break;
            case 2:
                shaderMat.SetVector("_Center3", ballPos);
                break;

            default:
                break;
        }
        radius[currentRipple] = 0;

        currentRipple++;
        if(currentRipple > 2)
        {
            currentRipple = 0;
        }
    }
}
