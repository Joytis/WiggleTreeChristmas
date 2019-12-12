﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseOnCollision : MonoBehaviour {
    [SerializeField] LayerMask _mask;

    public event Action CollidedWithThing;

    void OnCollisionEnter(Collision collision) {
        var other = collision.rigidbody;
        var layer = 1 << other.gameObject.layer;

        if((_mask.value & layer) == layer) {
            CollidedWithThing?.Invoke();
        }
    }

}