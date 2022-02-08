using System.Collections.Generic;
using UnityEngine;

public class Sphere : Item
{
    public Sphere() : base()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = ItemColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
