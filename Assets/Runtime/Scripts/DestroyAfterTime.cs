using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyAfterTime : MonoBehaviour {
    [SerializeField] float _time = 2f;
    void Awake() => Destroy(gameObject, _time);
}
