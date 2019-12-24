using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class SoundOnClick : MonoBehaviour {
    [SerializeField] SoundDef _sound = null;
    AudioSource _targetSource = null;

    void Awake() {
        _targetSource = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick() => _targetSource.PlayOneShot(_sound.Clip);
}