using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MapTextToHighScore : MonoBehaviour {
    TextMeshProUGUI _text = null;

    void Awake() => _text = GetComponent<TextMeshProUGUI>();
    void Update() => _text.text = string.Format("{0:000}", PlayerPrefs.GetInt(GameState.HighScoreName, 0));
}