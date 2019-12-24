using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Christmas/OrnamentLib")]
public class OrnamentLib : ScriptableObject
{
    [SerializeField] List<OrnamentDef> _ornaments = null;
    [SerializeField] GameObject _prefab = null;

    public GameObject CreateOrnament() {
        int totalWeight = _ornaments.Select(orn => orn.Weight).Sum();

        OrnamentDef SelectOrnament() {
            int randomWeight = Random.Range(0, totalWeight);
            foreach(var orn in _ornaments) {
                if(randomWeight < orn.Weight) {
                    return orn;
                }

                randomWeight -= orn.Weight;
            }
            throw new System.InvalidOperationException("Something weird happened.");
        }

        var ornamentDef = SelectOrnament();
        var newOrnament = Object.Instantiate(_prefab);

        // Set the mesh filter mesh. 
        newOrnament.GetComponent<MeshFilter>().sharedMesh = ornamentDef.Mesh;

        // Set the mesh collider mesh. 
        newOrnament.GetComponent<MeshCollider>().sharedMesh = ornamentDef.Mesh;

        return newOrnament;
    }
}
