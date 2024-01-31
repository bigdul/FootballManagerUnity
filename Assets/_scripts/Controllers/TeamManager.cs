using UnityEngine;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using System.Linq;

public class TeamManager : MonoBehaviour
{
    public static TeamManager Instance;

    public List<Team> teamSOs; // Assign Team Scriptable Objects in Unity Inspector
    public List<Team> instantiatedTeams = new List<Team>();

    private void Awake()
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

    public List<Team> GetAllTeams()
    {
        if (instantiatedTeams.Count < 1)
        {
            foreach (var teamSO in teamSOs)
            {
                Team teamInstance = Instantiate(teamSO); // Create runtime instances
                instantiatedTeams.Add(teamInstance);

                teamInstance.GenerateTeam();
                teamInstance.SetTeamId(instantiatedTeams.Count);
            }
        }

        return instantiatedTeams;
    }

    public Team GetTeam(int teamId)
    {
        return instantiatedTeams.FirstOrDefault(x=>x.TeamId == teamId);
    }
}
