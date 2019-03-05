using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{

    private bool inRangeOfItem;
    private GameObject itemInRange;

    private itemHandler currentItemHandleScript;

    private bool inRangeOfPodium;
    ItemDeposit depositPodScript;

    public List<string> inventory;

    public Canvas playerCanvas;
    public GameObject eventTextObj;

    void Start()
    {
        playerCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {     
        if(GameHandler.Instance.gameState == GameHandler.gameStates.navigating)
        {
            if (inRangeOfItem && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pickup Item");


                currentItemHandleScript.itemSelection();

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {

                }

                inventory.Add(itemInRange.name);

                inRangeOfItem = false;
                Destroy(itemInRange);
                itemInRange = null;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log(inventory);
            }

            if (inRangeOfPodium && Input.GetKeyDown(KeyCode.E))
            {
                bool hadItem = false;

                foreach (var item in inventory)
                {
                    if (item == depositPodScript.compareToStore)
                    {
                        hadItem = true;
                        inventory.Remove(item);
                        Debug.Log("Placed item on podium");
                        eventTextObj.GetComponent<Text>().text = "Level complete";
                        break;
                    }
                }
                if (hadItem == false)
                {
                    Debug.Log("You don't have the item");
                }

            }

            if(inRangeOfItem || inRangeOfPodium)
            {
                playerCanvas.gameObject.SetActive(true);
            }
            else
            {
                eventTextObj.GetComponent<Text>().text =  " ";
                playerCanvas.gameObject.SetActive(false);
            }
        }

        if(GameHandler.Instance.gameState == GameHandler.gameStates.selection)
        {
            playerCanvas.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Shake like an earthquake");
                eventTextObj.GetComponent<Text>().text = "Shaking Object...";
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                print("drop the bass");
                eventTextObj.GetComponent<Text>().text = "Dropped Object...";
            }

            if (GameHandler.Instance.buttonClickedOn == true)
            {
                currentItemHandleScript.itemSelected(GameHandler.Instance.buttonSelected);
                GameHandler.Instance.buttonClickedOn = false;
            } 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Entered Item Space");
            Debug.Log("Item is: " + other.gameObject.name);
            inRangeOfItem = true;
            itemInRange = other.gameObject;
            currentItemHandleScript = itemInRange.GetComponent<itemHandler>();
        }

        if (other.gameObject.CompareTag("Deposit"))
        {
            Debug.Log("Entered Podium Space");
            depositPodScript = other.gameObject.GetComponent<ItemDeposit>();
            inRangeOfPodium = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Left Item Space");
            inRangeOfItem = false;
            itemInRange = null;
            currentItemHandleScript = null;
        }

        if (other.gameObject.CompareTag("Deposit"))
        {
            Debug.Log("Left Podium Space");
            depositPodScript = null;
            inRangeOfPodium = false;
        }
    }
}
