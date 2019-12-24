using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SfxOnCollision : MonoBehaviour
{
    [SerializeField] SoundDef _sound = null;
    AudioSource _source = null;
    bool _canPlay = true;

    void Awake() => _source = GetComponent<AudioSource>();

    IEnumerator PlayCooldown() {
        _canPlay = false;
        yield return new WaitForSeconds(1f);
        _canPlay = true;
    }

    void OnCollisionEnter(Collision collision) {
        if(!_canPlay || collision.relativeVelocity.magnitude < 3) return;
        
        _source.PlayOneShot(_sound.Clip);
        StartCoroutine(PlayCooldown());
    } 
}
