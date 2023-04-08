using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private List<UIElement> UIElements;

    public void UpdateUI()
    {
        foreach (UIElement uiElement in UIElements)
        {
            uiElement.OnUIUpdate();
        }
    }
}
