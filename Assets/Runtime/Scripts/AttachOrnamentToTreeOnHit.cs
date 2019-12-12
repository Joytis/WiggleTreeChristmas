using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttachOrnamentToTreeOnHit : MonoBehaviour
{
    Rigidbody _rigidbody = null;

    void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void OnCollisionEnter(Collision collision) {
        var other = collision.rigidbody;

        // Only attach if we hit the christmas tree. 
        if(other.gameObject.layer != LayerMask.NameToLayer("ChristmasTree")) return;

        // Just make a joint and add our object to the tree.
        var newJoint = other.gameObject.AddComponent<FixedJoint>();
        // attach us!
        newJoint.connectedBody = _rigidbody;

        // We've been attached. No more!
        Destroy(this);
    }
}
