using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootOnClick : MonoBehaviour
{
    [SerializeField] OrnamentLib _ornamentLib = null;
    [SerializeField] AudioSource _audioSource = null;
    [SerializeField] SoundDef _shootSound = null;
    [SerializeField] float _velocity = 4f;

    [SerializeField] Vector2 _angularVelocityMinMax = new Vector2(-30, 30);

    Camera _cam = null;
    Camera Cam {
        get {
            if(_cam == null) _cam = Camera.main;
            return _cam;
        }
    }

    Vector2 _currentAim = Vector2.zero;
    InputMaster _input = null;

    void Awake() => _input = new InputMaster();

    void OnEnable() {
        _input.Enable();
        _input.player.aim.performed += OnAim;
        _input.player.shoot.performed += OnShoot;
    }

    void OnDisable() {
        _input.Disable();
        _input.player.aim.performed -= OnAim;
        _input.player.shoot.performed -= OnShoot;
    }

    public void OnAim(InputAction.CallbackContext ctx) {
        _currentAim = ctx.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext ctx) {
        var point = Cam.ScreenToWorldPoint(new Vector3(_currentAim.x, _currentAim.y, Cam.nearClipPlane));
        var direction = (point - Cam.transform.position).normalized;

        // Create the new ornament. 
        var newOrnament = _ornamentLib.CreateOrnament();
        var randomDirection = Random.insideUnitCircle.normalized;
        newOrnament.transform.position = point;
        newOrnament.transform.rotation = Quaternion.identity;
        newOrnament.transform.forward = randomDirection;

        // Set physical properties. 
        var rigidbody = newOrnament.GetComponent<Rigidbody>();
        rigidbody.velocity = direction * _velocity;

        float RandomVal() => Random.Range(_angularVelocityMinMax.x, _angularVelocityMinMax.x);
        rigidbody.AddTorque(new Vector3(RandomVal(), RandomVal(), RandomVal()));

        // Play a sound. 
        _audioSource.PlayOneShot(_shootSound.Clip);
    }

}
