using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerator : MonoBehaviour
{
    public enum ButtonType
    {
        Category,
        Activity,
    }

    [SerializeField]
    private UIViewsObject viewsObject;
    [SerializeField]
    private CategoriesObject categoriesObject;
    [SerializeField]
    private GameObject buttonObject;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Transform pool;

    private void Start()
    {
        //this is here temporarily,
        //don't feel like making another script or default view
        //just to call these 2 lines (yet)
        InitializeButtons();
        viewsObject.SetState(UIView.State.Categories);
    }

    private void InitializeButtons()
    {
        foreach (Category c in categoriesObject.Container.Categories)
        {
            GenerateButton(ButtonType.Category, c.CategoryName, null, c, null, null);

            foreach (Activity a in c.Activities)
            {
                GenerateButton(ButtonType.Activity, a.ActivityName, null, c, a, null);
            }
        }
    }

    public void GenerateButton(ButtonType bType, string buttonName, System.Action buttonInteraction = null, Category c = null, Activity a = null, Metric m = null)
    {
        GameObject button;
        ButtonBridge bb;
        button = GameObject.Instantiate(buttonObject, parent);

        bb = button.GetComponent<ButtonBridge>();
        switch (bType)
        {
            case ButtonType.Category:
                bb.SetData(buttonName, () =>
                    {
                        viewsObject.SetState(UIView.State.Activities);
                        viewsObject.SetCategoryParent(c);
                        buttonInteraction?.Invoke();
                    });
                viewsObject.OnViewStateChanged += () =>
                {
                    bool shouldRender = viewsObject.View.ViewState == UIView.State.Categories;
                    bb.Render(shouldRender, shouldRender ? parent : pool);
                };
                break;
            case ButtonType.Activity:
                bb.SetData(buttonName, () =>
                        {
                            viewsObject.SetState(UIView.State.Metrics);
                            viewsObject.SetActivityParent(a);
                            buttonInteraction?.Invoke();
                        });
                viewsObject.OnViewStateChanged += () =>
                    {
                        if (viewsObject.View.CParent == null) return;
                        bool shouldRender = viewsObject.View.ViewState == UIView.State.Activities && viewsObject.View.CParent.Activities.Contains(a);
                        bb.Render(shouldRender, shouldRender ? parent : pool);
                    };
                viewsObject.OnCategoryViewParentChanged += () =>
                    {
                        if (viewsObject.View.CParent == null) return;
                        bool shouldRender = viewsObject.View.CParent.Activities.Contains(a);
                        bb.Render(shouldRender, shouldRender ? parent : pool);
                    };
                break;
        }
    }
}
