using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour {
    bool _running = false;
    public float CurrentTime { get; set; } = 0f;

    public IEnumerator DoTimer() {
        if(_running) throw new InvalidOperationException("Wow! No!");
        _running = true;

        while(CurrentTime >= 0) {
            yield return null;
            CurrentTime -= Time.deltaTime;
        }
        CurrentTime = 0f;

        _running = false;
    }
}
