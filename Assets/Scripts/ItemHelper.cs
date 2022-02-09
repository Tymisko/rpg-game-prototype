using System.Collections.Generic;
using UnityEngine;

public static class ItemHelper
{
    private static readonly System.Random Random = new System.Random();
    public static Dictionary<Color, string> ItemsColors { get; private set; }
    public static List<Color> ItemsColorsKeys;
    private static List<string> ItemsColorsValues;

    static ItemHelper()
    {
        InitItemsColors();
    }
    
    private static void InitItemsColors()
    {
        ItemsColors = new Dictionary<Color, string>()
        {
            {UnityEngine.Color.red, "Red"},
            {UnityEngine.Color.green, "Green"},
            {UnityEngine.Color.yellow, "Yellow"}
        };
        ItemsColorsKeys = new List<Color>(ItemsColors.Keys);
        ItemsColorsValues = new List<string>(ItemsColors.Values);
    }

    public static Color GetRandomItemColor()
    {
        var randomIndex = Random.Next(0, ItemsColors.Count);
        return ItemsColorsKeys[randomIndex];
    }
}
