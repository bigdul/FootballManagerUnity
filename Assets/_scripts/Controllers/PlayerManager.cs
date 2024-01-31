using UnityEngine;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public List<Player> Players = new List<Player>();

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

    public int RegisterPlayer(Player player)
    {
        Players.Add(player);
        return Players.Count;
    }

    public Player GetPlayer(int playerId)
    {
        return Players.FirstOrDefault(x => x.PlayerId == playerId);
    }
}
