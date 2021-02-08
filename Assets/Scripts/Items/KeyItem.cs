using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour, ICollectable
{
    public Item itemInfo;



    /*--------------------------- ICollectable ------------------------------------*/
    public void Collect(InventoryManager inventoryManager)
    {
        if (inventoryManager.CanAddItem(itemInfo))
        {
            inventoryManager.AddItem("Llave", itemInfo);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes espacio!");
        }
    }

    public Item GetItemInfo()
    {
        return itemInfo;
    }
    //-----------------------------END ICollectable------------------------------*/



}
