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
    float[] radius = { 0, 0, 0, 0, 0 };
    float[] alphas = { 1, 1, 1, 1, 1 };

    int currentRipple;
    [HideInInspector]
    public int count;

    Color shaderColor;
    // Start is called before the first frame update
    void Start()
    {
        shaderColor = shaderMat.GetColor("_ColorBase");

        canRipple = true;

        for (int i = 0; i < radius.Length; i++)
        {
            shaderMat.SetVector("_Center" + (i + 1).ToString(), new Vector3(0, -1000, 0));
        }
        shaderMat.SetColor("_Color", new Color(shaderColor.r, shaderColor.g, shaderColor.b, 1.0f));

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

        for (int j = 0; j < alphas.Length; j++)
        {
            shaderMat.SetColor("_Color" + (j + 1).ToString(), new Color(shaderColor.r,shaderColor.g,shaderColor.b, alphas[j]));
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
                    StartCoroutine("fade",0);
                    break;
                case 1:
                    shaderMat.SetVector("_Center2", ballPos);
                    StartCoroutine("fade",1);
                    break;
                case 2:
                    shaderMat.SetVector("_Center3", ballPos);
                    StartCoroutine("fade",2);
                    break;
                case 3:
                    shaderMat.SetVector("_Center4", ballPos);
                    StartCoroutine("fade",3);
                    break;
                case 4:
                    shaderMat.SetVector("_Center5", ballPos);
                    StartCoroutine("fade",4);
                    break;

                default:
                    break;
            }

            radius[currentRipple] = 0;

            currentRipple++;
            count++;
            if (count >= radius.Length)
            {
                canRipple = false;
            }
            if (currentRipple >= radius.Length)
            {
                currentRipple = 0;
            }
        }
    }

    IEnumerator fade(int ripple)
    {

        alphas[ripple] = 1.0f;

        while (alphas[ripple] > 0.0f)
        {
            alphas[ripple] -= 0.01f;
            yield return new WaitForSeconds(.1f);
        }
    }
}
