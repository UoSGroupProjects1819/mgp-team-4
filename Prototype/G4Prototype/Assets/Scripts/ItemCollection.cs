using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    private bool inRangeOfItem;
    private GameObject itemInRange;

    private itemHandler currentItemHandleScript;

    private bool inRangeOfPodium;
    ItemDeposit depositPodScript;

    public List<string> inventory;

    void Start()
    {
        
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
                        break;
                    }
                }
                if (hadItem == false)
                {
                    Debug.Log("You don't have the item");
                }

            }
        }

        if(GameHandler.Instance.gameState == GameHandler.gameStates.selection)
        {
            if (Input.GetMouseButton(0))
            {
                print("Shake like an earthquake");
            }
            else if (Input.GetMouseButton(1))
            {
                print("drop the bass");
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                currentItemHandleScript.itemSelected();
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
