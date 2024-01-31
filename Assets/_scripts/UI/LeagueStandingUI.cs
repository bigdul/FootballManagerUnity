using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeagueStandingUI : MonoBehaviour
{
    public TextMeshProUGUI Standing, TeamName, Points;

    public void SetLeagueStandingText(LeagueTableEntry entry, int standing)
    {
        Standing.text = standing.ToString();
        TeamName.text = LinkBuilder.BuildLink(entry.Team);
        Points.text = entry.Points.ToString();
    }
}
