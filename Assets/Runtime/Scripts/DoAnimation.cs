using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoAnimation : MonoBehaviour {
    [SerializeField] string _name = null;
    Animator _animation = null;

    void Awake() => _animation = GetComponent<Animator>();

    public IEnumerator PlayAndWait() {
        _animation.Play(_name);

        //Wait until we enter the current state
        _animation.Update(0f);
        while (_animation.GetCurrentAnimatorStateInfo(0).IsName(_name)) {
            yield return null;
        }
    }
}