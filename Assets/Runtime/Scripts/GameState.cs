using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class GameState : MonoBehaviour
{
    static GameState _instance = null;
    public static GameState Instance {
        get {
            if(_instance == null) _instance = FindObjectOfType<GameState>();
            return _instance;
        }
    }

    [Title("DisableThings")]
    [SerializeField] List<MonoBehaviour> _enablableSubsystems = null;
    [SerializeField] GameObject _crosshair = null;

    [Title("Aniamtion Stuff")]
    [SerializeField] List<DoAnimation> _animationsAtStart = null;

    [Title("Game Components")]
    [SerializeField] RaiseOnCollision _starCollision = null;
    [SerializeField] SimpleTimer _timer = null;
    [SerializeField] float _gameTime = 15f;

    public int CurrentScore { get; private set; } = 0;
    public event Action<int> ScoreChanged;

    public void AddScore() {
        CurrentScore += 1;
        ScoreChanged?.Invoke(CurrentScore);
    }

    bool _starCollided = false;

    void OnStarCollision() => _starCollided = true;
    void Awake() => _starCollision.CollidedWithThing += OnStarCollision;

    IEnumerator Start() {
        yield return DoGame();
    }

    IEnumerator WaitOnStarCollision() {
        yield return new WaitUntil(() => _starCollided);
    }

    IEnumerator WaitForFirst(Action<Coroutine> setter, params Coroutine[] coroutines) {
        bool _finished = false;
        Coroutine _firstCoroutine = null;

        IEnumerator WaitAndSet(Coroutine coroutine) {
            yield return coroutine;
            _finished = true;
            _firstCoroutine = coroutine;
        }

        // Start a bunch of Coroutines that wait on the other coroutines. 
        var waiters = coroutines.Select(coro => StartCoroutine(WaitAndSet(coro))).ToArray();
        yield return new WaitUntil(() => _finished);

        // Stop all the waiter coroutines. They're no longer needed. 
        foreach(var coro in waiters) {
            StopCoroutine(coro);
        }

        // 'return' the value
        setter(_firstCoroutine);
    }

    void SetEnabledForSubsystems(bool enabled) {
        _crosshair.SetActive(enabled);
        foreach(var subsystem in _enablableSubsystems) {
            subsystem.enabled = enabled;
        }
    }

    // public void UnloadOldScene() {
    //     Debug.Log("Unloading scene.");
    //     IEnumerator UnloadOldSceneInternal() {
    //         Debug.Log("Unloading scene.");
    //         var menuScene = SceneManager.GetSceneByName("MainMenu");
    //         // If the main menu has been loaded, unload it. 
    //         Debug.Log("For real.");
    //         yield return SceneManager.UnloadSceneAsync(menuScene);
    //         Debug.Log("Done.");
    //     }
    //     StartCoroutine(UnloadOldSceneInternal());
    // }

    IEnumerator DoGame() {
        // Get rid of old scene. 
        // Debug.Log("Playing slide out");
        // yield return MainMenuScript.Instance.PlaySlideOut();

        Debug.Log("Starting game.");
        // Initialize systems. 
        // UnloadOldScene();
        SetEnabledForSubsystems(false);
        _timer.CurrentTime = _gameTime;

        // Wait a couple seconds. 
        yield return new WaitForSeconds(2.0f);

        // Show some animations at the start. 
        foreach(var anim in _animationsAtStart) {
            yield return anim.PlayAndWait();
        }
            
        // Turn on game. 
        SetEnabledForSubsystems(true);

        // Start Coroutines. 
        var timerCoroutine = StartCoroutine(_timer.DoTimer());
        var starCollision = StartCoroutine(WaitOnStarCollision());

        // Wait for the first one to finish. 
        Coroutine firstCoroutine = null;
        yield return WaitForFirst(coro => firstCoroutine = coro, timerCoroutine, starCollision);

        // Stop the coroutines. 
        StopCoroutine(timerCoroutine);
        StopCoroutine(starCollision);

        // Turn off game. 
        SetEnabledForSubsystems(false);

        // Wait for a second!
        yield return new WaitForSeconds(2.0f);

        // If it was the star, we lose. If it was the timer, we.. win?
        if(firstCoroutine == timerCoroutine) {
            Debug.Log("Win!");
        }
        else if(firstCoroutine == starCollision) {
            Debug.Log("Lose!");
        }
    }
}
