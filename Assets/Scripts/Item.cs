using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
