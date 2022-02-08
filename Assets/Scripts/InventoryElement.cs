using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string Name { get; }
    public Color Color { get; }

    public InventoryItem(string name, Color color)
    {
        Name = name;
        Color = color;
    }
}
