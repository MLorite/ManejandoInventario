using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DectectorItem
{
    public Transform detectorOrigin;
    public int distance = 30;
    public Character owner;
    [Header("Interface de Usuario")]
    public GameObject panelItem;
    public Text textName;
    public Text textDescription;
    public Text textNumberWeight;
    public Text textNumberCount;

    public void Detect()
    {
        /*
         * Detectar objetos del mundo
         * Estos objetos tiene ICollectable
         * Puedo leer la informacion del objeto detectado
         * Se recoge los objetos con el boton E del teclado
         */
        if (Physics.Raycast(detectorOrigin.transform.position, detectorOrigin.transform.forward, out RaycastHit hit, distance))
        {
            ICollectable collectable = hit.transform.GetComponent<ICollectable>();
            if (collectable != null)
            {
                Item actualItem = collectable.GetItemInfo();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    collectable.Collect(owner.inventoryManager);
                }
                //mostramos la interface de los objetos
                if (actualItem != null)
                {
                    panelItem.SetActive(true);
                    textName.text = actualItem.name;
                    textDescription.text = actualItem.description;
                    textNumberWeight.text = actualItem.weight.ToString();
                    textNumberCount.text = actualItem.count.ToString();
                }
                else
                {
                    // si el contenido del objeto es null, porque ya lo hemos cogido antes
                    panelItem.SetActive(false);
                }

            } else
            {
                // si no se detectan objetos, ocultamos la interface
                panelItem.SetActive(false);
            }

        }
    }

    public void DebugDetect()
    {
        Gizmos.DrawRay(detectorOrigin.position, detectorOrigin.forward * distance);
    }
}
