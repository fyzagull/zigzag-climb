using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _canJump = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (ControlUnit.Instance.GameActive)
        {
            // Jump if can jump
            if (_canJump)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    _rb.velocity = new Vector3(-10, 15);
                    StartCoroutine(JumpCoolDown());
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    _rb.velocity = new Vector3(10, 15);
                    StartCoroutine(JumpCoolDown());
                }


                //if (Input.touchCount > 0)
                //{
                //    if (Input.GetTouch(0).phase == TouchPhase.Began)
                //    {
                //        if (Input.GetTouch(0).position.x / Screen.width < 0.5f)
                //        {
                //            _rb.velocity = new Vector3(-10, 15);
                //            StartCoroutine(JumpCoolDown());
                //        }
                //        else if (Input.GetTouch(0).position.x / Screen.width >= 0.5f)
                //        {
                //            _rb.velocity = new Vector3(10, 15);
                //            StartCoroutine(JumpCoolDown());
                //        }
                //    }
                //}
            }
        }
    }

    IEnumerator JumpCoolDown()
    {
        _canJump = false;
        // Change the waiting value to add cooldown!
        yield return new WaitForSeconds(0f);
        _canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ControlUnit.Instance.GameActive)
        {
            if (collision.gameObject.tag == "Spike")
            {
                ControlUnit.Instance.EndTheGame();
            }
            else if (collision.gameObject.tag == "Jumper")
            {
                _rb.velocity = collision.transform.rotation * Vector3.up * 45f;
            }
        }
    }
}