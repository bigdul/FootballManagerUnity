using System;
using TMPro;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    internal void SetText(string v)
    {
        _text.text = v;
    }
}