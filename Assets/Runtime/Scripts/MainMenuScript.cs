using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuScript : MonoBehaviour
{
    static MainMenuScript _instance = null;
    public static MainMenuScript Instance {
        get {
            if(_instance == null) _instance = FindObjectOfType<MainMenuScript>();
            return _instance;
        }
    }

    [SerializeField] Animator _animator = null;
    [SerializeField] AudioSource _source = null;

    [SerializeField] float _fadeDuration = 0.3f;
    [SerializeField] Vector2 _audioMinMax = new Vector3(0.3f, 1.0f);

    const string GameScene = "GameScene";
    const string StartingScene = "StartupScene";

    bool _loading = false;

    void Awake() {
        _instance = this;
        _source.volume = _audioMinMax.y;
    }

    IEnumerator LoadScene(string scene) {
        // Load scene. 
        Scene currentScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        // Change active scene. 
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        yield return SceneManager.UnloadSceneAsync(currentScene);
    }

    public void LoadGame() {
        if(_loading) throw new InvalidOperationException("Already loading");
        IEnumerator Internal() {
            _loading = true;
            yield return LoadScene(GameScene);
            _source.DOFade(_audioMinMax.x, _fadeDuration);
            yield return _animator.PlayAndWait("SlideOut");
            _loading = false;
        }
        StartCoroutine(Internal());
    }

    public void LoadMainMenu() {
        if(_loading) throw new InvalidOperationException("Already loading");
        IEnumerator Internal() {
            _loading = true;
            yield return _animator.PlayAndWait("SlideIn");
            _source.DOFade(_audioMinMax.y, _fadeDuration);
            yield return LoadScene(StartingScene);
            _loading = false;
        }
        StartCoroutine(Internal());
    }
}
