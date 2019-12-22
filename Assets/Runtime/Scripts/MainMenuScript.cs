using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    static MainMenuScript _instance = null;
    public static MainMenuScript Instance {
        get {
            if(_instance == null) _instance = FindObjectOfType<MainMenuScript>();
            return _instance;
        }
    }

    // [SerializeField] Animator _animator = null;

    // void Awake() => DontDestroyOnLoad(gameObject);

    // public IEnumerator PlaySlideIn() {
    //     Debug.Log("Playing slide out");
    //     yield return _animator.PlayAndWait("SlideIn");
    // }

    // public IEnumerator PlaySlideOut() {
    //     yield return _animator.PlayAndWait("SlideOut");
    // }
}
