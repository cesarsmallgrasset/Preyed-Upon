using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    private Button StartButton;
    private Button EndButton;
    private Button OptionButton;
    private Sprite Start;
    private Sprite End;
    private Sprite Options;

    private void Awake()
    {
        StartButton = GetComponent<Button>();
        EndButton = GetComponent<Button>();
        OptionButton = GetComponent<Button>();

    }

    private void Update()
    {
        StartButton.onClick.Invoke();
        OptionButton.onClick.Invoke();
        EndButton.onClick.Invoke();
        
    }

    void StartGame()
    {



    }
}
