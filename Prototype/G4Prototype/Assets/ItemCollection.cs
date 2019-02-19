using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    private bool inRangeOfItem;
    private GameObject itemInRange;

    public List<string> inventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRangeOfItem && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pickup Item");
            inventory.Add(itemInRange.name);

            inRangeOfItem = false;            
            Destroy(itemInRange);
            itemInRange = null;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log(inventory);
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Left Item Space");
            inRangeOfItem = false;
            itemInRange = null;
        }
    }
}
