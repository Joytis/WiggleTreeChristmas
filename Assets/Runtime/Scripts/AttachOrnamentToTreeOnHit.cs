using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttachOrnamentToTreeOnHit : MonoBehaviour
{
    Rigidbody _rigidbody = null;
    bool _attached = false;

    void Awake() => _rigidbody = GetComponent<Rigidbody>();

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

        // We've been attached. No more!
        Destroy(this);
    }
}
