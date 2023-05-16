using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class ItemsScript : ScriptableObject
{
    /// <summary> Imagen del item </summary>
    public Sprite image;
    /// <summary> Tipo de item </summary>
    public ItemType type;
    /// <summary> Si es stackeable </summary>
    public bool stackable = true;
}

/// <summary> Tipos de Items </summary>
public enum ItemType                //Ejemplos
{
    TuberiaRecta,
    TuberiaCurva,
    TuberiaCruz,
    Llave,
    Martillo,
    Ladrillo,
    Manivela,
    Medallon1,
    Medallon2,
    Medallon3,
    PiezaMaquina,
    Palanca
}

