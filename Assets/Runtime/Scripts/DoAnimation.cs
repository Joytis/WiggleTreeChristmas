using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoAnimation : MonoBehaviour {
    [SerializeField] string _name = null;
    [SerializeField] SoundDef _sound = null;
    [SerializeField] AudioSource _targetSource = null;
    Animator _animation = null;

    void Awake() => _animation = GetComponent<Animator>();

    public IEnumerator PlayAndWait() {
        if(_sound != null) _targetSource.PlayOneShot(_sound.Clip);
        yield return _animation.PlayAndWait(_name);
    }
}