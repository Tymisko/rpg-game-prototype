using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ItemHelper
    {
        private static readonly System.Random Random = new System.Random();
        public static Dictionary<Color, string> ItemsColors { get; private set; }
        public static List<Color> ItemsColorsKeys;

        static ItemHelper()
        {
            InitItemsColors();
        }

        private static void InitItemsColors()
        {
            ItemsColors = new Dictionary<Color, string>()
            {
                {Color.red, "Red"},
                {Color.green, "Green"},
                {Color.yellow, "Yellow"}
            };
            ItemsColorsKeys = new List<Color>(ItemsColors.Keys);
        }

        public static Color GetRandomItemColor()
        {
            var randomIndex = Random.Next(0, ItemsColors.Count);
            return ItemsColorsKeys[randomIndex];
        }
    }
}