using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float _dissappearingDistance;

    void Update()
    {
        if (transform.position.y < ControlUnit.Instance.Ball.transform.position.y - _dissappearingDistance)
        {
            Destroy(gameObject);
        }
    }
}
