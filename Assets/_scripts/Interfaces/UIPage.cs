using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPage : MonoBehaviour
{
    public void Show()
    {
        this.DisplayUI();
        OnShow();
    }

    public void Show(Player player)
    {
        this.DisplayUI();
        OnShow(player);
    }

    public void Show(Team team)
    {
        this.DisplayUI();
        OnShow(team);
    }

    public void Show(Fixture fixture)
    {
        this.DisplayUI();
        OnShow(fixture);
    }

    protected virtual void OnShow() { }

    // Overloaded method for showing with a Player parameter
    protected virtual void OnShow(Player player) { }

    // Overloaded method for showing with a Club parameter
    protected virtual void OnShow(Team team) { }

    // Overloaded method for showing with a Fixture parameter
    protected virtual void OnShow(Fixture fixture) { }

    private void DisplayUI()
    {
        this.gameObject.transform.localScale = Vector3.one;
    }

    public void Hide()
    {
        this.gameObject.transform.localScale = Vector3.zero;
    }

}
