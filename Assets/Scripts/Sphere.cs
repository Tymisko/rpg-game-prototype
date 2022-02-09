using System;
using UnityEngine;

public class Sphere : Item
{ 
    void Start()
    {
        Color = ItemHelper.GetRandomItemColor();
        gameObject.GetComponent<MeshRenderer>().material.color = Color;
    }
}
