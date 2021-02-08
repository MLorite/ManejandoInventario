using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryManager
{
    private Dictionary<string, Item> inventory = new Dictionary<string,Item>();

    [Tooltip("Peso actual del inventario KG")]
    public float currentWeight = 0;
    [Tooltip("Peso maximo del inventario KG")]
    public float maxWeight = 10;
    [Header("Interface de Usuario")]
    public GameObject inventoryUI;
    public GameObject parentName;
    public GameObject parentWeight;
    public GameObject parentCount;

    /// <summary>
    /// Sirve para combrobar si un objecto se puede añadir o no
    /// </summary>
    /// <param name="item"></param> Objeto que intenta ser añadido al inventario
    /// <returns></returns> Devuelve true si el peso del objeto y el peso actual es inferior al peso maximo
    public bool CanAddItem(Item item)
    {
        /* 
         * Solo se pueden añadir objetos si el peso actual es menor al maximo
         */
        bool canAdd = currentWeight + item.GetCurrentWeight() < maxWeight;
        if (canAdd == false)
        {
            Debug.Log("El Objeto no cabe en el inventario");
        }
        return canAdd;
    }
    public float GetCurrentWeight()
    {
        float totalWeight = 0;
        foreach (var item in inventory)
        {
            totalWeight += item.Value.GetCurrentWeight();
        }
        return totalWeight;
    }
    public void AddItem(string key, Item item)
    {
        if (inventory.ContainsKey(key))
        {
            inventory[key].count += item.count;
        }
        else
        {
            inventory.Add(key, item);
        }
    }
    public bool RemoveItem(string key, int count)
    {
        /*
         * Si existe la key eliminamos la cantidad que nos indique = hemoseliminado = true
         * En caso de que la cantidad haga que el item se quede a 0, eliminamos el item = no hemos eliminado = 
         * En caso de que la cantidad que se pida sea mayor a la cantidad que tenemos no podemos eliminarlo
         * Si no existe la key, no podemos eliminar
         */
        /* Mi ejercicio
       if (inventory.ContainsKey(key))
       {
           if ((inventory[key].count -= count) < 0)
           {
               return false;
           }
           else if ((inventory[key].count -= count) == 0)
           {
               inventory.Remove(key);
               return true;
           }
           else
           {
               inventory[key].count -= count;
               return true;
           }
       }
       return false;     */

    if (inventory.TryGetValue(key, out Item item))
        {
            int currentCount = item.count - count;
            if (currentCount == 0) //eliminamos el item
            {
                inventory.Remove(key);
                return true;
            }
            else if (currentCount > 0) //eliminamos la cantidad de items
            {
                inventory[key].count = currentCount;
                return true;
            }
            else // <0
            {
                return false;
            }
        }
        else //no existe el objeto
        {
            return false;
        }


    }
    public Item GetItem(string key)
    {
        /*
         * Devuelve el objeto del inventario si existe
         * Si no existe devuelve nulo
         */
        if (inventory.TryGetValue(key, out Item item))
        {
            return item;
        }
        return null;

    }
    public void UpdateUI()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        }

        if (inventoryUI.activeInHierarchy)
        {
            //Cada vez que inicio una nueva lista la inicio con el numero de elementos del padre 
            List<Text> nameList = new List<Text>(parentName.GetComponentsInChildren<Text>());
            List<Text> weightList = new List<Text>(parentWeight.GetComponentsInChildren<Text>());
            List<Text> countList = new List<Text>(parentCount.GetComponentsInChildren<Text>());

            int count = 1;
            foreach (var item in inventory)
            {
                    nameList[count].text = item.Value.name;
                    weightList[count].text = item.Value.weight.ToString();
                    countList[count].text = item.Value.count.ToString();
                count++;
            }
        }
    }
}
