using System;
using TMPro;
using UnityEngine;

public class MatchEventUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    internal void SetText(string v)
    {
        _text.text = v;
    }
}