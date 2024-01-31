using System.Collections;
using System.Collections.Generic;
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
