using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Christmas/Sound")]
public class SoundDef : ScriptableObject
{
    [SerializeField] AudioClip[] _clips = null;

    public AudioClip Clip => _clips[Random.Range(0, _clips.Length)];
}
