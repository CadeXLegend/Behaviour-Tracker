using System;
using UnityEngine;
using TMPro;
using TheraBytes.BetterUi;

public class ButtonBridge : MonoBehaviour
{
    [SerializeField]
    private GameObject child;
    [SerializeField]
    private BetterButton button;
    [SerializeField]
    private TMP_Text textComponent;

    public void Render(bool shouldRender, Transform parent)
    {
        child.SetActive(shouldRender);
        transform.SetParent(parent);
    }

    public void SetData(string text)
    {
        textComponent.text = text;
    }

    public void SetData(Action interaction)
    {
        if (interaction == null) return;
        button.onClick.AddListener(delegate { interaction?.Invoke(); });
    }

    public void SetData(string text, Action interaction)
    {
        textComponent.text = text;
        if (interaction == null) return;
        button.onClick.AddListener(delegate { interaction?.Invoke(); });
    }
}
