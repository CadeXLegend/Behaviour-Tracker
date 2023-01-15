using System;
using UnityEngine;
using TMPro;

public class TextComponentBridge : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent;
    [SerializeField]
    private UIViewsObject viewsObject;

    public void SetData(string text)
    {
        textComponent.text = text;
    }

    public void SetDataAppendViewState(string text)
    {
        textComponent.text = $"{text} {viewsObject.View.ViewState.ToString()}";
    }
}
