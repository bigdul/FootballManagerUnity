using UnityEngine;

public class FixtureListUI : UIPage
{
    public static FixtureListUI Instance { get; private set; }

    private int weekFocus = 0;

    [SerializeField] private Transform _fixtureContainer;
    [SerializeField] private GameObject _resultPrefab;

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

    public void ChangeWeekFocus(int amount)
    {
        weekFocus = weekFocus + amount < 0 ? 0 : weekFocus + amount > FixturesManager.Instance.MatchWeeks.Count - 1 ? weekFocus : weekFocus + amount;

        SetupFixturesPanel();
    }

    protected override void OnShow()
    {
        SetupFixturesPanel();
    }

    private void SetupFixturesPanel()
    {
        ClearFixtures();

        //Set up Results panel
        foreach (Fixture f in FixturesManager.Instance.MatchWeeks[weekFocus].fixtures)
        {
            var obj = Instantiate(_resultPrefab, _fixtureContainer);
            obj.GetComponent<FixtureUI>().SetFixtureText(f);
        }
    }

    private void ClearFixtures()
    {
        foreach (Transform t in _fixtureContainer)
        {
            Destroy(t.gameObject);
        }
    }
}