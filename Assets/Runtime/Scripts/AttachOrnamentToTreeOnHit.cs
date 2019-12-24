using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class AttachOrnamentToTreeOnHit : MonoBehaviour
{
    [SerializeField] SoundDef _soundEffect = null;
    [SerializeField] GameObject _vfx = null;
    MeshFilter _filter = null;
    Rigidbody _rigidbody = null;
    bool _attached = false;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _filter = GetComponent<MeshFilter>();
    }

    public void LoadOrnament(OrnamentDef def) {
        _filter.mesh = def.Mesh;
    }

    void OnCollisionEnter(Collision collision) {
        if(_attached) return;
        var other = collision.gameObject;

        // Only attach if we hit the christmas tree. 
        if(other.layer != LayerMask.NameToLayer("ChristmasTree")) return;
        _attached = true;

        // Just make a joint and add our object to the tree.
        var newJoint = other.gameObject.AddComponent<FixedJoint>();
        // attach us!
        newJoint.connectedBody = _rigidbody;
        GameState.Instance.AddScore();
        AudioSource.PlayClipAtPoint(_soundEffect.Clip, transform.position);

        // Create vfx
        ContactPoint contact = collision.contacts[0];
        var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        var pos = contact.point;
        Instantiate(_vfx, pos, rot);

        // We've been attached. No more!
        Destroy(this);
    }
}
