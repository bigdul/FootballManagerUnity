using UnityEngine;
using System.Collections.Generic;
using UnityEditor.AssetImporters;

public class TeamManager : MonoBehaviour
{
    public static TeamManager Instance;

    public List<Team> teamSOs; // Assign Team Scriptable Objects in Unity Inspector
    private List<Team> instantiatedTeams = new List<Team>();

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
            }
        }

        return instantiatedTeams;
    }
}
