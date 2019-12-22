using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BloopWiggle : MonoBehaviour {
    [SerializeField] float _from = 0.3f;
    [SerializeField] float _to = 1f;
    [SerializeField] float _time = 0.4f;
    [SerializeField] float _delay = 0f;
    [SerializeField] AnimationCurve _ease = default(AnimationCurve);

    void OnEnable() {
        transform.DOScale(_to, _time).From(_from).SetEase(_ease).SetDelay(_delay);
    }
}