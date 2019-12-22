using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootOnClick : MonoBehaviour
{
    [SerializeField] GameObject _thingToShoot = null;
    [SerializeField] float _velocity = 4f;
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

        var newOrnament = Instantiate(_thingToShoot, point, Quaternion.identity);
        var rigidbody = newOrnament.GetComponent<Rigidbody>();
        rigidbody.velocity = direction * _velocity;
    }

}
