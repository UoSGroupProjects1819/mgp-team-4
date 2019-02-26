using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderHandler : MonoBehaviour
{

    public Material shaderMat;
    public float rippleRadius;
    [HideInInspector]
    public bool canRipple;

    public float rippleSpeed;
    public float fadeDuration;
    float[] radius = { 0,0,0,0,0 };

    int currentRipple;
    [HideInInspector]
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        canRipple = true;

        for (int i = 0; i < radius.Length; i++)
        {
            shaderMat.SetVector("_Center" + (i + 1).ToString(), new Vector3(0,-1000,0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < radius.Length; i++)
        {
            if (radius[i] <= rippleRadius)
            {
                radius[i] += Time.deltaTime * rippleSpeed;

                shaderMat.SetFloat("_Radius" + (i + 1).ToString(), radius[i]);

            }
        }             
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Vector3 ballPos = transform.position;

        if (canRipple)
        {
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
                case 3:
                    shaderMat.SetVector("_Center4", ballPos);
                    break;
                case 4:
                    shaderMat.SetVector("_Center5", ballPos);
                    break;

                default:
                    break;
            }

            radius[currentRipple] = 0;

            currentRipple++;
            count++;
            if(count >= radius.Length)
            {
                canRipple = false;
            }
            if (currentRipple >= radius.Length)
            {
                currentRipple = 0;
            }
        }
    }
}
