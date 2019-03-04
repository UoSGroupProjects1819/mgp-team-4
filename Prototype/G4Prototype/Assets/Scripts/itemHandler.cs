using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemHandler : MonoBehaviour
{
    public GameObject ballObject;
    public float checkRadius = 1.5f;

    public string[] potentialItems = new string[3];
    private string actualItem;

    private ParticleSystem particleSys;

    public GameObject selectionCanvas;
    public GameObject leftTextObj;
    public GameObject centerTextObj;
    public GameObject rightTextObj;

    public AudioSource shakeSound;
    public AudioSource dropSound;

    private Text leftText;
    private Text centerText;
    private Text rightText;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Ball");
        actualItem = gameObject.name;

        particleSys = gameObject.GetComponent<ParticleSystem>();
        particleSys.Stop();

        //selectionCanvas = GameObject.Find("canvasSelection");
        //leftTextObj = selectionCanvas.transform.GetChild(0).gameObject;
        //centerTextObj = selectionCanvas.transform.GetChild(1).gameObject;
        //rightTextObj = selectionCanvas.transform.GetChild(2).gameObject;

        leftText = leftTextObj.GetComponent<Text>();
        centerText = centerTextObj.GetComponent<Text>();
        rightText = rightTextObj.GetComponent<Text>();

        selectionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(ballObject.transform.position, gameObject.transform.position) < checkRadius)
        {
            particleSys.Play();
        }   
    }

    public void itemSelection()
    {
        GameHandler.Instance.gameState = GameHandler.gameStates.selection;

        print("ye");
        leftText.text = potentialItems[0];
        centerText.text = potentialItems[1];
        rightText.text = potentialItems[2];

        selectionCanvas.SetActive(true);
    }

    public void itemSelected()
    {
        GameHandler.Instance.gameState = GameHandler.gameStates.navigating;
        selectionCanvas.SetActive(false);

        //handle the selected option and points or whatever it is
    }
}
