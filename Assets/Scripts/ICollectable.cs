using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    /// <summary>
    /// Devuelve informacion sobre el objetico que tiene implementada esta clase
    /// </summary>
    /// <returns></returns>
    Item GetItemInfo();

    /// <summary>
    /// Accion de recoger por el character
    /// </summary>
    /// <param name="inventoryManager"></param>
    void Collect(InventoryManager inventoryManager);
}
