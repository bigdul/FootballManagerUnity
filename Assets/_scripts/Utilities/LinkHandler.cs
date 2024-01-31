using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI textMeshPro;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
            HandleLinkClick(linkInfo.GetLinkID());
        }
    }

    private void HandleLinkClick(string linkID)
    {

        string[] splitID = linkID.Split('/');

        if (splitID.Length != 2)
        {
            Debug.LogError("Invalid link format");
            return;
        }

        string type = splitID[0];
        string id = splitID[1];

        if (int.TryParse(id, out int result))
        {
            switch (type)
            {
                case "player":
                    UIManager.Instance.ShowPlayerDetails(result);
                    Debug.Log($"Clicked player with id: {id}");
                    break;
                case "club":
                    UIManager.Instance.ShowClubDetails(result);
                    Debug.Log($"Clicked club with id: {id}");
                    break;
                default:
                    Debug.LogError("Unknown link type");
                    break;
            }
        }
    }
}
