using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlUnit : MonoBehaviour
{
    public static ControlUnit Instance { get; private set; }

    public GameObject Ball { get; private set; }
    public bool GameActive { get; set; }
    public bool GameEnded { get; set; }

    [SerializeField] private GameObject[] _ballPrefabs;
    [SerializeField] private UIManager _uIManager;

    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SpawnTheBall();
        Screen.SetResolution(480, 853, false);
    }
    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        if (GameEnded == false)
        {
            if (_uIManager.NotAvailableToStart == false)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    _uIManager.StartGame();
            }
        }
    }

    private void SpawnTheBall()
    {
        int ballIndex = 0;
        if (PlayerPrefs.HasKey("BallIndex"))
            ballIndex = PlayerPrefs.GetInt("BallIndex");
        Ball = Instantiate(_ballPrefabs[ballIndex], Vector3.zero, Quaternion.identity);
    }

    public void SelectBall(int idx)
    {
        PlayerPrefs.SetInt("BallIndex", idx);
        Destroy(Ball);
        SpawnTheBall();
    }

    public void EndTheGame()
    {
        Debug.Log("<b>Game Ended</b>");
        GameActive = false;
        GameEnded = true;
        _uIManager.EndGame();
    }
}