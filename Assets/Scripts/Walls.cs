using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private int _wallStackCount = 4;
    private float _height;

    void Start()
    {
        _height = 42.84f;
    }

    void Update()
    {
        if (transform.GetChild(0).GetComponent<Collider>().bounds.min.y < ControlUnit.Instance.Ball.transform.position.y - 20 - (_wallStackCount - 2.5f) * _height)
        {
            transform.position += new Vector3(0, (_wallStackCount) * _height);
        }
    }
}
