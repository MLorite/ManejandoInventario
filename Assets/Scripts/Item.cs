using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item 
{
    [Tooltip("Nombre del objeto que vamos a visualizar en el HUD")]
    public string name;
    [Tooltip("Informacion sobre el objeto cuando el jugador pulsa el boton izquierdo")]
    public string description;
    [Tooltip("Peso del objeto individual")]
    public float weight;
    [Tooltip("Peso actual de los objetos")]
    public int count = 1;

    /// <summary>
    /// Peso actual del objeto
    /// ¡Cuidado! Si el count = 0 o el weight = 0 entonces el peso total sera 0!
    /// </summary>
    /// <returns></returns>
    public float GetCurrentWeight()
    {
        return count * weight;
    }
}
