using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;

    public GameObject PlayGroundObject;
    public GameObject TasksScreen;

    void Awake()
    {
        startButton.onClick.AddListener(ActivateGame);
    }

    void ActivateGame()
    {
        PlayGroundObject.SetActive(true);
        TasksScreen.SetActive(true);
        startButton.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        startButton.onClick.RemoveAllListeners();
    }
}
