using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    event Action<GameObject> OnItemRemoved;
    Color Color { get; }

}
