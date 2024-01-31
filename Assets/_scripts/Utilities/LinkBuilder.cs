using UnityEngine.UI;

public static class LinkBuilder
{
    //Generate a link to a team page
    public static string BuildLink(Team team)
    {
        return $"<link=\"club/{team.TeamId}\">{team.teamName}</link>";
    }

    //Generate a link to a player details page
    public static string BuildLink(Player player)
    {
        return $"<link=\"player/{player.PlayerId}\">{player.FullName}</link>";
    }
}