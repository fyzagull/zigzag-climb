using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMuter : MonoBehaviour
{
    private Animator _animator;
    private Image _image;

    [SerializeField] Sprite _spriteNormal;
    [SerializeField] Sprite _spriteMuted;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();

        if (PlayerPrefs.HasKey("Muted") && PlayerPrefs.GetInt("Muted") == 1)
        {
            _image.sprite = _spriteMuted;
            AudioManager.Instance.SetVolume(0f);
        }
    }

    public void SwitchSprites()
    {
        if (_image.sprite == _spriteNormal)
        {
            _image.sprite = _spriteMuted;
            AudioManager.Instance.SetVolume(0f);
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            _image.sprite = _spriteNormal;
            AudioManager.Instance.SetVolume(0.2f);
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}
