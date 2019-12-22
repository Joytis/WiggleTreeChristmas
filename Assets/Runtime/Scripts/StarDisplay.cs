using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StarDisplay : MonoBehaviour {
    [SerializeField] Sprite _active = null;
    [SerializeField] Sprite _inactive = null;
    [SerializeField] int _threshold = 0;

    // Start is called before the first frame update
    void Awake() {
        var image = GetComponent<Image>();
        var sprite = GameState.Instance.CurrentScore >= _threshold ? _active : _inactive;
        image.sprite = sprite;
    }
}
