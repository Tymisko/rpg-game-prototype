using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class InputHelper
    {
        public static readonly List<KeyCode> MovementKeys = new List<KeyCode>()
        {
            KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D,
            KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow
        };

        public static bool AnyKeyDown(List<KeyCode> keys)
        {
            foreach (var key in keys)
            {
                if (Input.GetKey(key)) return true;
            }

            return false;
        }
    }
}

