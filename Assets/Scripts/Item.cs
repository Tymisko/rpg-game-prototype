using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private static System.Random _random = new System.Random(); 
    public Color ItemColor { get; private set; }
    protected static List<Color> ItemsColors;

    public Item()
    {
        InitItemsColors();
        ItemColor = GetRandomItemColor();
    }
    void Start()
    {
        
    }

    private void InitItemsColors()
    {
        ItemsColors = new List<Color>
        {
            UnityEngine.Color.red,
            UnityEngine.Color.green,
            UnityEngine.Color.yellow
        };
    }

    private static Color GetRandomItemColor()
    {
        int randomIndex = _random.Next(0, ItemsColors.Count);
        return ItemsColors[randomIndex];
    }
}
