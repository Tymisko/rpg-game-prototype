using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Sphere", menuName = "ScriptableObjects/SphereScriptableObject", order = 1)]
    public class SphereScriptableObject : ScriptableObject
    {
        public string Name = "Sphere";
    }
}

