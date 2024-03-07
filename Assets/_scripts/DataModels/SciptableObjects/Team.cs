using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Team", menuName = "SportsLeague/Team")]
public class Team : ScriptableObject
{
    public string teamName;


    public int YearFounded;
    public int StadiumCapacity;

    private int _teamId;

    public void SetTeamId(int id) {  _teamId = id; }
    public int TeamId => _teamId;

    public float AvgAttacking => Mathf.Round((float)Players.Average(x => x.Attacking));
    public float AvgDefending => Mathf.Round((float)Players.Average(x => x.Defending));
    public float AvgTechnique => Mathf.Round((float)Players.Average(x => x.Technique));
    public float AvgPhysical => Mathf.Round((float)Players.Average(x => x.Physical));

    [HideInInspector]
    public int CurrentScore;

    public List<Player> Players = new List<Player>();

    public void GenerateTeam()
    {
        for(int i = 0; i < 11; i++)
        {
            var newPlayer = new Player(this);
            Players.Add(newPlayer);

            var id = PlayerManager.Instance.RegisterPlayer(newPlayer);
            newPlayer.SetPlayerId(id);
        }
    }
}
