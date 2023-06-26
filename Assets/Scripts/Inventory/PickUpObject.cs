using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private GameObject itemObj;

    public Item item;

    void Start()
    {
        itemObj = gameObject;
    }

    private void OnMouseOver()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //gameObject.SetActive(false);
            Inventory.instance.PutInEmptySlot(item);
            Destroy(gameObject);
        }
    }

    // private void OnMouseExit()
    // {
    //     Indicator.enabled = false;
    // }
}
