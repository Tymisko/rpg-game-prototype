using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Sphere : Item
    {
        public SphereScriptableObject ScriptableObject;

        void Start()
        {
            Color = ItemHelper.GetRandomItemColor();
            gameObject.GetComponent<MeshRenderer>().material.color = Color;
        }
    }
}