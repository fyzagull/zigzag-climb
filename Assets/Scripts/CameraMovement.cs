using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _elevator;

    private Transform _target;
    private float _specialZ = -31.1f;

    private void Start()
    {
        float ratio = (float)Screen.width / Screen.height;

        print(8f / 16f);
        print(ratio);
        if (ratio > 8f / 16f)
        {
            _specialZ = -25.71f;
        }
        else if (ratio > 8.5f / 18f)
        {
            _specialZ = -28.52f;
        }
        else if (ratio > 8f / 20f)
        {
            _specialZ = -31.1f;
        }
            transform.position = new Vector3(transform.position.x, transform.position.y, _specialZ);
    }


    //[SerializeField] private float _risingSpeed;
    //[SerializeField] private float _upperFollowGap;

    private void Update()
    {
        if (ControlUnit.Instance.GameActive)
        {
            _elevator.position += Vector3.up * 5f * Time.deltaTime;
            var _ballElevatorDistance = ControlUnit.Instance.Ball.transform.position.y - _elevator.transform.position.y;

            if (_ballElevatorDistance > 0)
            {
                _target = ControlUnit.Instance.Ball.transform;
                if (ControlUnit.Instance.Ball.transform.position.y - _elevator.position.y >= 3)
                    _elevator.position = new Vector3(0, ControlUnit.Instance.Ball.transform.position.y - 3);
            }
            else
            {
                _target = _elevator.transform;
            }

            if (_ballElevatorDistance < -17f)
            {
                ControlUnit.Instance.EndTheGame();
            }

            // Skorlarý göster
            int score = ((int)_target.position.y);
            ControlUnit.Instance.Score1.text = score.ToString();
            ControlUnit.Instance.Score2.text = score.ToString();

            if (PlayerPrefs.HasKey("MaxScore"))
            {
                if (PlayerPrefs.GetInt("MaxScore") < score)
                {
                    PlayerPrefs.SetInt("MaxScore", score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("MaxScore", score);
            }
        }
        else
        {
            _target = null;
        }
        if (_target != null)
        {
            var targetPos = new Vector3(transform.position.x, _target.position.y, _specialZ);
            transform.position = Vector3.Lerp(transform.position, targetPos, 4f * Time.deltaTime);
        }
    }
}