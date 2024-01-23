using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPage : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.transform.localScale = Vector3.one;
        OnShow();
    }

    protected virtual void OnShow() { }

    // Overloaded method for showing with a Player parameter
    //protected virtual void OnShow(Player player) { }

    // Overloaded method for showing with a Club parameter
    //protected virtual void OnShow(Club club) { }

    public void Hide()
    {
        this.gameObject.transform.localScale = Vector3.zero;
    }

}
