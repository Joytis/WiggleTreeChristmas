using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField] string _scene = null;

    // Start is called before the first frame update
    void Start() => SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
}
