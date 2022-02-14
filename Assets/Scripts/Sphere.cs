using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
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