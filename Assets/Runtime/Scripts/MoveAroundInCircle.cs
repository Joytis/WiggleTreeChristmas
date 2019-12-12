using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundInCircle : MonoBehaviour {
    [SerializeField] float _degreesPerSecond = 30f;
    [SerializeField] Transform _cameraHandle = null;

    // Update is called once per frame
    void Update() {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(_cameraHandle.position, Vector3.up, _degreesPerSecond * Time.deltaTime);
    }
}
