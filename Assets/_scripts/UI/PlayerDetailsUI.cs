using System;
using TMPro;
using UnityEngine;

public class PlayerDetailsUI : UIPage
{
    public static PlayerDetailsUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private Transform _statContainer;
    [SerializeField] private GameObject _statPrefab;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    protected override void OnShow(Player player)
    {
        base.OnShow(player);
        ClearStats();

        _playerName.text = player.FullName;
        _teamName.text = $"Plays for {LinkBuilder.BuildLink(player.Team)}";

        PopulateStats(player);
    }

    private void PopulateStats(Player player)
    {
        Instantiate(_statPrefab, _statContainer).GetComponent<StatUI>().SetText($"{player.Attacking} Attacking");
        Instantiate(_statPrefab, _statContainer).GetComponent<StatUI>().SetText($"{player.Defending} Defending");
        Instantiate(_statPrefab, _statContainer).GetComponent<StatUI>().SetText($"{player.Physical} Physical");
        Instantiate(_statPrefab, _statContainer).GetComponent<StatUI>().SetText($"{player.Technique} Technique");
    }

    private void ClearStats()
    {
        foreach (Transform child in _statContainer)
        {
            Destroy(child.gameObject);
        }
    }
}