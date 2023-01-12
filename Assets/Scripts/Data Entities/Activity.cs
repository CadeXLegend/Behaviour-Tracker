using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Activity", menuName = "Data/Activity", order = 2)]
[System.Serializable]
public class Activity
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private string activityName = "";
    public string ActivityName { get => activityName; }
    [SerializeField]
    private List<Metric> metrics = new List<Metric>();
    public List<Metric> Metrics { get => metrics; }

    public Activity(Sprite icon, string ActivityName, List<Metric> Metrics)
    {
        this.icon = icon;
        this.activityName = ActivityName;
        this.metrics = Metrics;
    }
}
