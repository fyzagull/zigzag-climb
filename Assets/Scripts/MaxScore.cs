using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxScore : MonoBehaviour
{
    private TextMeshProUGUI _txtMesh;

    void Start()
    {
        _txtMesh = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("MaxScore"))
        {
            _txtMesh.text = PlayerPrefs.GetInt("MaxScore").ToString();
        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            _txtMesh.text = PlayerPrefs.GetInt("MaxScore").ToString();
        }
    }
}
