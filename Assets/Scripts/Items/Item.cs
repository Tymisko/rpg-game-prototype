using System;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        public event Action<GameObject> OnItemRemoved;
        public Color Color { get; protected set; }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagsHelper.Player))
            {
                OnItemRemoved?.Invoke(gameObject);
                Destroy(gameObject);
            }
        }

        protected object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}