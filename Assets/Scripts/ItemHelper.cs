using System.Collections.Generic;
using UnityEngine;

public static class ItemHelper
{
    private static readonly System.Random _random = new System.Random();
    public static Dictionary<Color, string> ItemsColors { get; private set; }
    public static List<Color> ItemsColorsKeys;
    public static List<string> ItemsColorsValues;

    static ItemHelper()
    {
        InitItemsColors();
        ItemsColorsKeys = new List<Color>(ItemsColors.Keys);
        ItemsColorsValues = new List<string>(ItemsColors.Values);
    }
    
    private static void InitItemsColors()
    {
        ItemsColors = new Dictionary<Color, string>()
        {
            {UnityEngine.Color.red, "Red"},
            {UnityEngine.Color.green, "Green"},
            {UnityEngine.Color.yellow, "Yellow"}
        };
    }

    public static Color GetRandomItemColor()
    {
        int randomIndex = _random.Next(0, ItemsColors.Count);
        return ItemsColorsKeys[randomIndex];
    }
}
