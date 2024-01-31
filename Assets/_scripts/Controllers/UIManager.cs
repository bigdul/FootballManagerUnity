using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private PlayerDetailsUI playerDetailsUI;
    private ClubDetailsUI clubDetailsUI;
    private FixtureListUI fixtureListUI;
    private HomePageUI homePageUI;

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

    private void Start()
    {
        playerDetailsUI = PlayerDetailsUI.Instance;
        clubDetailsUI = ClubDetailsUI.Instance;
        fixtureListUI = FixtureListUI.Instance;
        homePageUI = HomePageUI.Instance;

        //Start by showing home page
        ShowHomePage();
    }

    public void ShowPlayerDetails(int playerID)
    {
        HideAllUI();

        var player = PlayerManager.Instance.GetPlayer(playerID);

        playerDetailsUI.Show(player);
    }

    public void ShowClubDetails(int clubID)
    {
        HideAllUI();

        var team = TeamManager.Instance.GetTeam(clubID);

        clubDetailsUI.Show(team);
    }

    public void ShowFixtureList()
    {
        HideAllUI();
        fixtureListUI.Show();
    }

    public void ShowHomePage()
    {
        HideAllUI();
        homePageUI.Show();
    }

    private void HideAllUI()
    {
        // Hide all UI panels
        playerDetailsUI.Hide();
        clubDetailsUI.Hide();
        fixtureListUI.Hide();
        homePageUI.Hide();
    }
}
