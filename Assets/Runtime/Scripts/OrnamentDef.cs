using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Christmas/Ornament")]
public class OrnamentDef : ScriptableObject
{
    [SerializeField] int _weight = 1;
    public int Weight => _weight;

    [SerializeField] Mesh _mesh = null;
    public Mesh Mesh => _mesh;
}
