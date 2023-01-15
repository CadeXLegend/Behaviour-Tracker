using UnityEngine;

[CreateAssetMenu(fileName = "New UIViewsObject", menuName = "Data/UIViewsObject", order = 99)]
public class UIViewsObject : ScriptableObject
{

    [SerializeField]
    private UIView view;
    public UIView View { get => view; }

    public delegate void ViewStateEvent();
    public ViewStateEvent OnViewStateChanged;
    public ViewStateEvent OnCategoryViewParentChanged;
    public ViewStateEvent OnActivityViewParentChanged;
    public ViewStateEvent OnMetricViewParentChanged;

    public void SetState(UIView.State state)
    {
        view.SetState(state);
        OnViewStateChanged?.Invoke();
        switch (state)
        {
            case UIView.State.Category:
                SetCategoryParent(null);
                SetActivityParent(null);
                SetMetricParent(null);
                break;
            case UIView.State.Activity:
                SetActivityParent(null);
                SetMetricParent(null);
                break;
            case UIView.State.Metric:
                SetMetricParent(null);
                break;
            case UIView.State.None:
                SetCategoryParent(null);
                SetActivityParent(null);
                SetMetricParent(null);
                break;
        }
    }

    public void SetCategoryParent(Category category)
    {
        view.SetCategoryParent(category);
        OnCategoryViewParentChanged?.Invoke();
    }

    public void SetActivityParent(Activity activity)
    {
        view.SetActivityParent(activity);
        OnActivityViewParentChanged?.Invoke();
    }

    public void SetMetricParent(Metric metric)
    {
        view.SetMetricParent(metric);
        OnMetricViewParentChanged?.Invoke();
    }

    public void GoBackOneState()
    {
        if (view.ViewState <= 0) return;
        SetState(view.ViewState - 1);
    }
}
