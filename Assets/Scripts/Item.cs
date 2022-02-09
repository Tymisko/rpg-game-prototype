using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        public event Action<GameObject> OnItemRemoved;
        public Color Color { get; protected set; }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
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