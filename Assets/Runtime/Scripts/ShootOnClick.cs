using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootOnClick : MonoBehaviour
{
    [SerializeField] GameObject _thingToShoot = null;
    [SerializeField] float _velocity = 4f;
    Camera _cam = null;

    Vector2 _currentAim = Vector2.zero;

    void Awake() => _cam = Camera.main;

    public void OnAim(InputAction.CallbackContext ctx) {
        _currentAim = ctx.ReadValue<Vector2>();
    }

    public void OnShoot() {
        var point = _cam.ScreenToWorldPoint(new Vector3(_currentAim.x, _currentAim.y, _cam.nearClipPlane));
        var direction = (point - _cam.transform.position).normalized;

        var newOrnament = Instantiate(_thingToShoot, point, Quaternion.identity);
        var rigidbody = newOrnament.GetComponent<Rigidbody>();
        rigidbody.velocity = direction * _velocity;
    }
    
}
