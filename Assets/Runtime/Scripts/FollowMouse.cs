using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    InputMaster _input = null;
    RectTransform _transform = null;
    Vector2 _currentAim = Vector2.zero;

    void Awake() {
        _input = new InputMaster();
        _transform = GetComponent<RectTransform>();
    }

    void OnEnable() {
        _input.Enable();
        _input.player.aim.performed += OnAim;
    }

    void OnDisable() {
        _input.Disable();
        _input.player.aim.performed -= OnAim;
    }

    void OnAim(InputAction.CallbackContext ctx) {
        _currentAim = ctx.ReadValue<Vector2>();
    }

    void Update() {
        float halfWidth = Screen.width / 2f;
        float halfHeight = Screen.height / 2f;

        _transform.anchoredPosition = new Vector2(_currentAim.x - halfWidth, _currentAim.y - halfHeight);
    }
}
