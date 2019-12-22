using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class HomeButton : MonoBehaviour {
    void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);

    void OnClick() => MainMenuScript.Instance.LoadMainMenu();
}
