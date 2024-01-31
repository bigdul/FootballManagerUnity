using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamPlayerUI : MonoBehaviour
{

    public TextMeshProUGUI PlayerName;

    public void SetPlayer(Player player)
    {
        PlayerName.text = LinkBuilder.BuildLink(player);
    }
}
