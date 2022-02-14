using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ICollectable
    {
        event Action<GameObject> OnItemRemoved;
        Color Color { get; }
    }
}