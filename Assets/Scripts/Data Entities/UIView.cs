using UnityEngine;

[System.Serializable]
public class UIView
{
    public enum State
    {
        None,
        Categories,
        Activities,
        Metrics,
    }

    [SerializeField]
    private State viewState;
    public State ViewState { get => viewState; }

    [SerializeField]
    private Category cParent;
    public Category CParent { get => cParent; }
    [SerializeField]
    private Activity aParent;
    public Activity AParent { get => aParent; }
    [SerializeField]
    private Metric mParent;
    public Metric MParent { get => mParent; }

    public void SetCategoryParent(Category cParent)
    {
        this.cParent = cParent;
    }

    public void SetActivityParent(Activity aParent)
    {
        this.aParent = aParent;
    }

    public void SetMetricParent(Metric mParent)
    {
        this.mParent = mParent;
    }

    public void SetState(State state)
    {
        viewState = state;
    }
}
