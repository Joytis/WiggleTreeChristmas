using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoAnimation : MonoBehaviour {
    [SerializeField] string _name = null;
    Animator _animation = null;

    void Awake() => _animation = GetComponent<Animator>();

    public IEnumerator PlayAndWait() => _animation.PlayAndWait(_name);
}