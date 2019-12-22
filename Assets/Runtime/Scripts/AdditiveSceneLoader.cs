using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField] string _scene = null;
    static bool _loadedMenu = false;

    // Start is called before the first frame update
    void Start() {
        if(_loadedMenu) return;
        SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
        _loadedMenu = true;
    } 
}
