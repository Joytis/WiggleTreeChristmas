using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MapTextToTimer : MonoBehaviour {
    [SerializeField] SimpleTimer _timer = null;
    TextMeshProUGUI _text = null;

    void Awake() => _text = GetComponent<TextMeshProUGUI>();
    void Update() => _text.text = $"<mspace=90>{string.Format("{0:00.00}", _timer.CurrentTime)}";
}
