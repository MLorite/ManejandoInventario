using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DectectorItem detectorItem;

    private void Update()
    {
        detectorItem.Detect();
        inventoryManager.UpdateUI();
    }

    private void OnDrawGizmos()
    {
        detectorItem.DebugDetect();
    }
}
