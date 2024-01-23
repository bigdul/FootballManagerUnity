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

    public void ShowPlayerDetails(string playerID)
    {
        HideAllUI();
        playerDetailsUI.Show();
    }

    public void ShowClubDetails(string clubID)
    {
        HideAllUI();
        clubDetailsUI.Show();
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
