using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MapTextToScore : MonoBehaviour {
    TextMeshProUGUI _text = null;
    [SerializeField] Animator _animator = null;

    void UpdateText(int score) => _text.text = string.Format("{0:000}", score);

    void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
        GameState.Instance.ScoreChanged += UpdateScore;
        UpdateText(GameState.Instance.CurrentScore);
    }

    void UpdateScore(int score) {
        UpdateText(score);
        _animator.Play("Bloop", -1, 0f);
    }
}
