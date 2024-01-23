using UnityEngine;

public class PlayerDetailsUI : UIPage
{
    public static PlayerDetailsUI Instance { get; private set; }


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
}