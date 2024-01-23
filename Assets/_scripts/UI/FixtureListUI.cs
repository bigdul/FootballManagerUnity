using UnityEngine;

public class FixtureListUI : UIPage
{
    public static FixtureListUI Instance { get; private set; }


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