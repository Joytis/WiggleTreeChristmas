using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class PlayButtonPressed : MonoBehaviour
{
    [SerializeField] Animator _animator = null;
    [SerializeField] string _gameSceneName = null;
    bool _pressed = false;

    void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);

    void OnClick() {
        if(_pressed) return;
        _pressed = true;

        IEnumerator OnClickInternal() {
            // Load scene. 
            Scene currentScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Additive);
            // Change active scene. 
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_gameSceneName));
            yield return SceneManager.UnloadSceneAsync(currentScene);

            // Get rid of old scene. 
            yield return _animator.PlayAndWait("SlideOut");
        }
        StartCoroutine(OnClickInternal());
    }
}
