using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator _sound;

    private Animator _animator;

    public bool NotAvailableToStart { get; private set; } = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        _animator.SetTrigger("StartGame");
        _sound.SetTrigger("StartGame");
        ControlUnit.Instance.GameActive = true;
        if ((PlayerPrefs.HasKey("Muted") && PlayerPrefs.GetInt("Muted") == 1) == false)
        {
            AudioManager.Instance.SetVolume(0.5f);
        }
    }

    public void EndGame()
    {
        _animator.SetTrigger("EndGame");
        if ((PlayerPrefs.HasKey("Muted") && PlayerPrefs.GetInt("Muted") == 1) == false)
        {
            AudioManager.Instance.SetVolume(0.2f);
        }
    }

    public void Slide()
    {
        NotAvailableToStart = true;
        _animator.SetTrigger("Slide");
    }

    public void DeSlide()
    {
        NotAvailableToStart = false;
        _animator.SetTrigger("DeSlide");
    }

    public void SelectBall(int idx)
    {
        ControlUnit.Instance.SelectBall(idx);
    }

    public void ShowInfo()
    {
        _animator.SetTrigger("ShowInfo");
        NotAvailableToStart = true;
    }

    public void HideInfo()
    {
        _animator.SetTrigger("HideInfo");
        NotAvailableToStart = false;
    }
}
