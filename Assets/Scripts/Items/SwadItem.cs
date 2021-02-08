using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwadItem : MonoBehaviour, ICollectable
{
    public Item itemInfo;
    public AudioClip swordCollected;
    public AudioClip swordCanNotCollected;
    public AudioSource audioSource;
    bool hasCollected = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collect(InventoryManager inventoryManager)
    {
        if (hasCollected) return; //esto te saca del resto de ejecuciones, si hasCollected es true Sale, si es false, hace lo demás
        if (inventoryManager.CanAddItem(itemInfo))
        {
            //suena un sonido
            audioSource.PlayOneShot(swordCollected);
            inventoryManager.AddItem("Espada", itemInfo);
            hasCollected = true;
        } else
        {
            audioSource.PlayOneShot(swordCanNotCollected);
        }

    }

    public Item GetItemInfo()
    {
        if (hasCollected) return null;
        return itemInfo;

    }
}
