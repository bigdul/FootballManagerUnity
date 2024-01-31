using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Player
{
    public Team Team;
    public int Attacking, Defending, Technique, Physical;

    private string _firstName, _lastName;
    private int _playerId;

    public void SetPlayerId(int id) { _playerId = id; }
    public int PlayerId => _playerId;

    public string FullName => string.Concat(_firstName, " ", _lastName);

    public Player(Team team)
    {
        Team = team;

        Attacking = Random.Range(1, 10);
        Defending = Random.Range(1, 10);
        Technique = Random.Range(1, 10);
        Physical = Random.Range(1, 10);


        _firstName = GetFirstName();
        _lastName = GetSurname();
    }

    public string GetFirstName()
    {
        string[] names = new string[] { "James", "Oliver", "Ethan", "Liam", "Alexander", "Noah", "Lucas", "Mason", "Logan", "Samuel", "Daniel", "Michael" };
        var rnd = Random.Range(0, names.Length);

        return names[rnd];
    }

    public string GetSurname()
    {
        string[] names = new string[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez" };
        var rnd = Random.Range(0, names.Length);

        return names[rnd];
    }
}